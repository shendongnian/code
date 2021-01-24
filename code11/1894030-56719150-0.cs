    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class BoulbeFishDirection : MonoBehaviour
    {
        public Rigidbody2D rb2;
        public bool fishdirection = false;
        public float sidewaysforce = 1;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.CompareTag("LeftEdge"))
            {
                fishdirection = true;
                Debug.Log("Fish is going right");
            }
            else if(collider.CompareTag("RightEdge"))
            {
                fishdirection = false;
                Debug.Log("Fish is going left");
            }
        }
        void FixedUpdate()
        {
            if (fishdirection == true)
            {
                rb2.AddForce(new Vector2(sidewaysforce * Time.deltaTime, 0));
            }
            else if (fishdirection == false)
            {
                rb2.AddForce(new Vector2(-sidewaysforce * Time.deltaTime, 0));
            }
        }
    }
