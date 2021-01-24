    using System.Collections;
    using UnityEngine;
    
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeedup;
        public float moveSpeeddown;
        public float rotateSpeed;
        public bool moveup;
        public bool movedown;
        public bool rotateleft;
        public bool rotateright;
        public Transform body;
        void Update()
        {
            if ((Input.GetKey(KeyCode.UpArrow)) || moveup)
            {
                body.Translate(Vector3.right * moveSpeedup * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow) || movedown)
            {
                body.Translate(-Vector3.right * moveSpeeddown * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow) || rotateleft)
            {
                body.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow) || rotateright)
            {
                body.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);
            }
        }
    }
