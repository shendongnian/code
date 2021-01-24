    public class ProjectileScript : MonoBehaviour
    {
         public float speed = 1.0f;
        private RigidBody _rigidbody;
        private void Awake()
        {
            _rigidbody = GetComponent<RigidBody>();
        }
        public void SetDirection(Vector3 direction)
        {
            _rigidbody.velocity = direction.normalized * speed;
        }
    }
