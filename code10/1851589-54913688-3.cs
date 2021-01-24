    public class LookAtCamera : MonoBehaviour
    {
        // Values that will be set in the Inspector
        public Transform target;
        public float RotationSpeed;
    
        private float timer = 0.0f;
        public bool IsRotationFinished
        {
            get { return timer > 0.99f; }
        }
    
        // Update is called once per frame
        void Update()
        {
            if (target != null && timer < 0.99f)
            {
                // Rotate us over time according to speed until we are in the required rotation
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation((target.position - transform.position).normalized),
                    timer);
    
                timer += Time.deltaTime * RotationSpeed;
            }
            else
            {
                timer = 0.0f;
            }
        }
    }
