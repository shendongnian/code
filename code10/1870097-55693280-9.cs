    public class SmoothFollow2D : MonoBehaviour
    {
        [Header("Components")]
        [Tooltip("The target this will follow")]
        [SerializeField] private Transform target;
        [Header("Settings")]
        [Tooltip("This may never be 0!")]
        [SerializeField] private float minVelocity = 0.1f;
        [SerializeField] private float maxVelocity = 5.0f;
        [Tooltip("The deceleration radius around the target.\nThis may never be 0!")]
        [SerializeField] private float targetRadius = 1.0f;
        [Tooltip("How much speed shall be added per second?\n" +
                 "If this is equal to MaxVelocity you know that it will take 1 second to accelerate from 0 to MaxVelocity.\n" +
                 "Should not be 0")]
        [SerializeField] private float accelerationFactor = 3.0f;
        private float _currentVelocity;
        private float _lastVelocityOutsideTargetRadius;
        private bool _enableOrbit;
        public bool EnableOrbit
        {
            get { return _enableOrbit; }
            private set
            {
                // if already the same value do nothing
                if (_enableOrbit == value) return;
                _enableOrbit = value;
                // Whatever shall be done if orbit mode is enabled or disabled
            }
        }
        private void Update()
        {
            if (target == null) return;
            var distanceToTarget = Vector2.Distance(transform.position, target.position);
            // This is the threshold Unity uses for equality of vectors (==)
            // you might want to change it to a bigger value in order to
            // make the Camera more stable e.g.
            if (distanceToTarget <= 0.00001f)
            {
                EnableOrbit = true;
                // do nothing else 
                return;
            }
            EnableOrbit = false;
            if (distanceToTarget <= targetRadius)
            {
                // decelerate
                // This will make it slower 
                // the closer we get to the target position
                _currentVelocity = _lastVelocityOutsideTargetRadius * (distanceToTarget / targetRadius);
                // as long as it is not in the final position
                // it should always keep a minimum speed
                _currentVelocity = Mathf.Max(_currentVelocity, minVelocity);
            }
            else
            {
                // accelerate
                _currentVelocity += accelerationFactor * Time.deltaTime;
                // Limit to MaxVelocity
                _currentVelocity = Mathf.Min(_currentVelocity, maxVelocity);
                _lastVelocityOutsideTargetRadius = _currentVelocity;
            }
            transform.position = Vector2.MoveTowards(transform.position, target.position, _currentVelocity * Time.deltaTime);
        }
        // Just for visualizing the decelerate radius around the target
        private void OnDrawGizmos()
        {
            if (target) Gizmos.DrawWireSphere(target.position, targetRadius);
        }
    }
