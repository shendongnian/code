    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MoveToSettings : MonoBehaviour
    {
        public float speed = 5f;
        public float distanceToMove;
    
        private bool keepMoving = true;
        private Vector3 startPos;
        private Vector3 endPos;
        private bool moveBack = false;
    
        private void Start()
        {
            startPos = transform.position;
            endPos = transform.position - transform.right * distanceToMove;
        }
    
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {    
                transform.position = Vector3.MoveTowards(startPos, endPos, speed * Time.deltaTime);
            }
        }
    }
