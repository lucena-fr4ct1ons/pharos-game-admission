﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] int damageToDeal;
    [SerializeField] float stunTime;
    [SerializeField] Vector3 knockback;
    [SerializeField] GameObject owner;

    Vector3 bufferVector = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        if (!owner || !other.gameObject.Equals(owner))
            DealDamage(other.gameObject);
    }

    public void DealDamage(GameObject target)
    {
        if (target.GetComponent<Stats>())
        {
            target.GetComponent<Stats>().DealDamage(damageToDeal, knockback);
            if(GetComponent<Projectile>())
            {
                Destroy(gameObject);
            }
            else if (transform.parent.eulerAngles.y >= 265 && transform.eulerAngles.y <= 275)
            {
                knockback.x *= -1;
            }
            //bufferVector = knockback;
            //bufferVector.x *= owner.GetComponent<PlayerController>().GetBodyRotation();
            //target.GetComponent<Rigidbody>().AddForce(bufferVector * target.GetComponent<PlayerController>().GetDamage());
        }
    }
}
