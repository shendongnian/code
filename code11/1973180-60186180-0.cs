    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class playerdeath : MonoBehaviour
    {
    
             void OnCollisionEnter(Collision collision)
             {
                 foreach (ContactPoint contact in collision.contacts)
                 {
                     Debug.DrawRay(contact.point, contact.normal, Color.white);
                     Debug.Log("collision detected");
                 }
                 if(collision.relativeVelocity.magnitude > 2)
                 {
    
                     Destroy(gameObject);
                 }
                 if(other.gameObject.tag=="deathcube")
                 {
                   Destroy(gameObject); 
                 } 
             }
    }
