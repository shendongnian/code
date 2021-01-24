    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Shooting : MonoBehaviour
    {
        [SerializeField]
        private Transform[] firePoints;
        [SerializeField]
        private Rigidbody projectilePrefab;
        [SerializeField]
        private float launchForce = 700f;
        [SerializeField]
        private Animator anim;
        [SerializeField]
        private bool automaticFire = false;
        [SerializeField]
        private bool slowDownEffect = false;
        
        private void Start()
        {
            anim.SetBool("Shooting", true);
        }
    
        public void Update()
        {
            if (isAnimationStatePlaying(anim, 0, "AIMING") == true)
            {
                if (Input.GetButtonDown("Fire1") && automaticFire == false)
                {
                    if (anim.GetBool("Shooting") == true)
                    {
                        anim.Play("SHOOTING");
                        LaunchProjectile();
                    }
                }
                else
                {
                    if (automaticFire == true)
                    {
                        anim.Play("SHOOTING");
                        LaunchProjectile();
                    }
                }
            }
        }
    
        private void LaunchProjectile()
        {
            foreach (var firePoint in firePoints)
            {
                Rigidbody projectileInstance = Instantiate(
                    projectilePrefab,
                    firePoint.position,
                    firePoint.rotation);
    
                projectileInstance.AddForce(new Vector3(0, 0, 1) * launchForce);
    
                projectileInstance.gameObject.AddComponent<BulletDestruction>().Init();
            }
        }
    
        bool isAnimationStatePlaying(Animator anim, int animLayer, string stateName)
        {
            if (anim.GetCurrentAnimatorStateInfo(animLayer).IsName(stateName))
                return true;
            else
                return false;
        }
    }
