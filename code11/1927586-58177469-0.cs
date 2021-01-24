    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Teleport : MonoBehaviour
    {
        public Transform teleportTarget;
        public Rigidbody player;
    
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                player.transform.position = teleportTarget.position;
            }
        }
    }
