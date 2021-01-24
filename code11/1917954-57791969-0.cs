    public class Example : MonoBehaviour
    {
        private Rigidbody2D rb;
        private Camera _camera;
    
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
    
            // set an initial velocity
            rb.velocity = Vector2.one;
        }
    
        private void FixedUpdate()
        {
            // no touch -> do nothing
            if(Input.touchCount != 1) return;
    
            // get touch position in pixels
            var touchPosition = Input.GetTouch(0).position;
    
            // get touch position in world space
            var pos = _camera.ScreenToWorldPoint(touchPosition);
    
            // get current movement magnitude (in order to keep speed)
            var magnitude = rb.velocity.magnitude;
    
            // get vector center -> obj
            var gravityVector = transform.position - pos;
    
            // check whether touching left or right of target direction
            var left = Vector3.SignedAngle(rb.velocity, gravityVector, Vector3.forward) > 0;
    
            // get a vector 90° on gravityVector and world forward (since 2D game)
            var newDirection = Vector3.Cross(gravityVector, Vector3.forward).normalized;
    
            // have to invert in case we touched right of the former direction
            if (!left) newDirection *= -1;
    
            // apply the new direction
            rb.velocity = newDirection * magnitude;
        }
    }
    
