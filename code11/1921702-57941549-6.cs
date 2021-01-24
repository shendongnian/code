    public class Move2D : MonoBehaviour {
        // ...
    
        [SerializeField]
        private float speed;
    
        private Rigidbody2D rigidBody;
    
        private Vector2 currentMoveDirection;
    
        private void Awake() {
            rigidBody = GetComponent<Rigidbody2D>();
            currentMoveDirection = Vector2.zero;
        }
    
        // ...
    
        private void FixedUpdate() {
            rigidBody.velocity = (currentMoveDirection + new Vector2(0f, rigidBody.velocity.y)).normalized * speed;
        }
    
        public void TriggerMoveLeft() {
            currentMoveDirection += Vector2.left;
        }
    
        public void StopMoveLeft() {
            currentMoveDirection -= Vector2.left;
        }
    
        public void TriggerMoveRight() {
            currentMoveDirection += Vector2.right;
        }
    
        public void StopMoveRight() {
            currentMoveDirection -= Vector2.right;
        }
    }
