    using UnityEngine;
    
    public class Move : MonoBehaviour
    {
        public float speed = 5f;
        public float distancetoMove = 1f;
        public bool goForward;
        public Vector3 startPos;
        public Vector3 endPos;
    
        private void Start()
        {
            startPos = transform.position;
            endPos = transform.position - Vector3.forward * distancetoMove;
        }
    
        void Update()
        {
            if (goForward)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            }
        }
    
        private void OnMouseOver()
        {
            goForward = true;
        }
    
        private void OnMouseExit()
        {
            goForward = false;
        }
    }
