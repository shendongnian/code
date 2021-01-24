    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class SmoothMove : MonoBehaviour 
    {
        public float speed = 0.01f;
        private Vector3 destination;
    
        void Start()
        {
            destination = transform.position;
        }
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, destination, speed)
        }
        void SetDestination(Vector3 newPos)
        {
            destination = newPos;
        }
    }
