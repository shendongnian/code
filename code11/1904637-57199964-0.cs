    public class CameraMove : MonoBehaviour 
    {
        public static bool start = false; 
        public Vector3 targetPosition;
        // it's easier to adjust euler angles instead
        public Vector3 targetRotation;
        // here now set the rotation speed in degrees / second
        public float speed = 90f;
    
        void Start()
        {
            StartCoroutine(cameraRotate());
        }
    
        private IEnumerator cameraRotate()
        {
            // Trigger cameraMove until clicking the sphere
            yield return new WaitUntil(() => start == true);
    
            var startRotation = transform.localRotation;
            var finalRotation = Quaternion.Euler(targetRotation);
            // angle difference / angle per second => duration in seconds
            var duration = Quaternion.Angle(startRotation, finalRotation) / speed;
    
            var timePassed = 0f;
    
            while (timPassed < duration)
            {
                // with this factor you get a linear rotation like using Quaternion.RotateTowards ...
                var lerpFactor = timPassed / duration;
                // ... Huge advantage: You can now add ease-in and ease-out to the rotation!
                var smoothedLerpFactor = Mathf.SmoothStep(0, 1, lerpFactor);
    
                transform.localRotation = Quaternion.Lerp(startRotation, finalRotation, smoothedLerpFactor);
    
                // add to the timePassed avoiding overshooting
                timaPassed += Mathf.Min(duration - timePassed, Time.deltaTime);
                yield return null;
            }
    
            // to be sure set the rotation fixed when done
            transform.localRotation = finalRotation;
        }
    }
