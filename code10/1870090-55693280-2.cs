    public class SmoothFollow2D : MonoBehaviour
    {
        [Tooltip("This may never be 0!")]
        public float MinVelocity = 0.1f;
        public float MaxVelocity = 1.0f;
        [Tooltip("This may never be 0!")]
        public float TargetRadius;
        // How much speed shall be added per second
        public float accelerationFactor;
        [Tooltip("The target this will follow")]
        public Transform Target;
        private float currentVelocity;
        private float lastVelocityOutsideTargetRadius;
        private bool _enableOrbit;
        private bool EnableOrbit
        {
            get { return _enableOrbit; }
            set
            {
                // if already the same value do nothing
                if (_enableOrbit == value) return;
                _enableOrbit = value;
                // Whatever shall be done if orbit mode is enabled or disabled
            }
        }
        private void Update()
        {
            var distanceToTarget = Vector2.Distance(transform.position, Target.position);
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
            if (distanceToTarget <= TargetRadius)
            {
                // decelerate
                // This will make it slower 
                // the closer we get to the target position
                currentVelocity = lastVelocityOutsideTargetRadius * (distanceToTarget / TargetRadius);
                // as long as it is not in the final position
                // it should always keep a minimum speed
                currentVelocity = Mathf.Max(currentVelocity, MinVelocity);
            }
            else
            {
                // accelerate
                currentVelocity += accelerationFactor * Time.deltaTime;
                // Limit to MaxVelocity
                currentVelocity = Mathf.Min(currentVelocity, MaxVelocity);
                lastVelocityOutsideTargetRadius = currentVelocity;
            }
            transform.position = Vector2.MoveTowards(transform.position, Target.position, currentVelocity * Time.deltaTime);
        }
    }
