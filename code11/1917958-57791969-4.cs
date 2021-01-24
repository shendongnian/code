    public class Example : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Camera _camera;
        [SerializeField] private Vector2 initialVelocity;    
        private bool doGravitation;
        private Vector2 centerPos;
        private void Awake()
        {
            if(!rb) rb = GetComponent<Rigidbody2D>();
            if(!_camera) _camera = Camera.main;
    
            rb.velocity = initialVelocity;
        }
    
        private void Update()
        {
            // check for touch support otherwise use mouse as fallback
            // (for debugging on PC)
            if (Input.touchSupported)
            {
                // not touching or too many -> do nothing
                if (Input.touchCount != 1)
                {
                    doGravitation = false;
                    return;
                }
    
                var touchPosition = Input.GetTouch(0).position;
                centerPos = _camera.ScreenToWorldPoint(touchPosition);
                doGravitation = true;
            }
            else
            {
                // mouse not pressed -> do nothing
                if (!Input.GetMouseButton(0))
                {
                    doGravitation = false;
                    return;
                }
    
                centerPos = _camera.ScreenToWorldPoint(Input.mousePosition);
                doGravitation = true;
            }
        }
        private void FixedUpdate()
        {
            if(!doGravitation) return;
    
            // get current magnitude
            var magnitude = rb.velocity.magnitude;
    
            // get vector center <- obj
            var gravityVector = centerPos - rb.position;
    
            // check whether left or right of target
            var left = Vector2.SignedAngle(rb.velocity, gravityVector) > 0;
    
            // get new vector which is 90° on gravityDirection 
            // and world Z (since 2D game)
            // normalize so it has magnitude = 1
            var newDirection = Vector3.Cross(gravityVector, Vector3.forward).normalized;
    
            // invert the newDirection in case user is touching right of movement direction
            if (!left) newDirection *= -1;
    
            // set new direction but keep speed(previously stored magnitude)
            rb.velocity = newDirection * magnitude;
        }
    }
    
