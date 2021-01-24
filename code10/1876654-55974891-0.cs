    using UnityEngine;
    
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour {
    
        private Rigidbody2D rigidbody2D;
        private Vector2 velocity;
        public float playerMoveSpeed = 6; //the value that you want
    
        private float HorizontalMov;
        private float VerticalMov;
    
        void Awake() {
            rigidbody2D = this.GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            HorizontalMov = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
            VerticalMov = Input.GetAxis("Vertical") * playerMoveSpeed * Time.deltaTime;
            AddVelocity(new Vector2(HorizontalMov, VerticalMov));
            rigidbody2D.velocity = velocity;
        }
    
        public void AddVelocity(Vector2 newVelocity) {
            velocity += newVelocity;
        }
    
    }
