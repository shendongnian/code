    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Shooting : MonoBehaviour
    {
        public GameObject projectile;
        public Animator anim;
    
        private void Start()
        {
            anim.SetBool("Shooting", true);
        }
    
        private void Update()
        {
            if (anim.GetBool("Shooting") == true)
            {
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.VelocityChange);
            }
        }
    }
