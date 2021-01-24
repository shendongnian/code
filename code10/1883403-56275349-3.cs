    public class FollowPlayer : MonoBehaviour
    {
        public Transform PlayerTransform;
        public RigidBody rigiBody;
        public speed;
    
        private void Awake()
        {
           rigidBody = GetComponent<RigidBody>();
        }
        
        private void LateUpdate()
        {
            if(!PlayerTrasnform) return;
    
            var rotation = Quaternion.LookRotation(PlayerTransform.position - transform.position, Vector3.up);
    
            rigidBody.MoveRotation(rotation);
            rigidBody.velocity = (PlayerTransform.position - transform.position).normalized * speed;
        }
    }
