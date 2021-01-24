    using System.Collections.Generic;
    using System.Collections;
    using UnityEngine;
    using System;
    
    public class IceTile : MonoBehaviour
    {
    
        internal Vector3 m_MyTravelPoint;
        public GameObject explosionEffect;
    
        private void Start()
        {
            m_MyTravelPoint = transform.position + new Vector3(0, 0.61f, 0);
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(m_MyTravelPoint, 0.5f);
        }
        void Update()
        {
        
        }
        void OnMouseDown()
        {
            // this object was clicked - do something
            Instantiate(explosionEffect, transform.position);
            Destroy(this.gameObject);
        }
    }
