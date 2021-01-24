    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class OnMouseOverEvent : MonoBehaviour
    {
        public float duration;
        public string tag;
        public Vector3 startPos;
        public Vector3 endPos;
        public float distancetoMove = 1f;
        public float lerpTime = 5;
        float Perc;
    
        private float currentLerpTime = 0;
    
        private void Start()
        {
            startPos = transform.position;
            endPos = transform.position - Vector3.forward * distancetoMove;
        }
    
        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
    
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.transform.tag == tag)
                {
                    currentLerpTime += Time.deltaTime;
                    if (currentLerpTime >= lerpTime)
                    {
                        currentLerpTime = lerpTime;
                    }
    
                    Perc = currentLerpTime / lerpTime;
                    transform.position = Vector3.Lerp(transform.position, endPos, Perc);
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, startPos, Perc);
                }
            }
        }
    }
