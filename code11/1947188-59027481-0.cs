    public class movingCharacter : MonoBehaviour 
    {
        [Header("References")]
        public Rigidbody rb;
    
        [Header("Settings")]
        public float movingSpeed = 200;
        public int maxSpeed = 3000;
    
        [Header("Debug")]
        [SerializeField] private bool _forwardBackMoving;
        [SerializeField] private bool _sideMoving;
    
        // Now make properties. When setting a new value run your checks
        public bool forwardBackMoving
        {
            get => _forwardBackMoving;
            set
            {
                // do nothing if the value hasn't changed
                if(_forwardBackMoving == value) return;
    
                // otherwise apply the new value and run the check
                _forwardBackMoving = value; 
                CheckMovement();
            }
        }
    
        // The same fot he other flag
        public bool sideMoving
        {
            get => _sideMoving;
            set
            {
                // do nothing if the value hasn't changed
                if(_sideMoving == value) return;
    
                // otherwise apply the new value and run the check
                _sideMoving = value;
                CheckMovement();
            }
        }
    
        private void CheckMovement()
        {
            if ((forwardBackMoving || sideMoving) && movingSpeed < maxSpeed)
            {
                CancelInvoke();
                InvokeRepeating(nameof(increaseSpeed), 5.0f, 5.0f);
            }
            else if(!forwardBackMoving && !sideMoving)
            {
                CancelInvoke();
                InvokeRepeating(nameof(decreaseSpeed), 1.0f, 5.0f);
            }
        }
    
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            forwardBackMoving = true;
            sideMoving = true;
        }
    
        private void keyUpEvent()
        {
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                forwardBackMoving = false;
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                sideMoving = false;
            }
        }
        
        private void increaseSpeed() 
        {
            movingSpeed = movingSpeed * 1.1f;
            Debug.Log("Increased");
        }
    
        private void decreaseSpeed()
        {
            movingSpeed = movingSpeed * 0.9f;
            Debug.Log("Decreased");
        }
        
        // You should get Input only in the Update method!
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(transform.forward * movingSpeed);
                forwardBackMoving = true;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                rb.AddForce(transform.right * -movingSpeed);
                sideMoving = true;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.AddForce(transform.forward * -movingSpeed);
                 forwardBackMoving= true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rb.AddForce(transform.right * movingSpeed);
                sideMoving = true;
            }
            keyUpEvent();
            // Avoid Debug.Log on a per frame basis! It is quite expensive!
            Debug.Log(Time.deltaTime);
        }
    }
