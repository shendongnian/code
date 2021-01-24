    public class RayReceiver : MonoBehaviour
    {
        [Header("Settings")]
        public float turnOffDelay = 0.5f;
    
        [Header("Debug")]
        public bool isHitByRay;
        public Vector2 incomingHitDirection;
        public Vector2 incomingHitPoint;
    
        private void Start()
        {
            isHitByRay = false;
        }
    
        public void HitWithRay(Vector2 hitPoint, Vector2 hitDirection)
        {
            // stop evtl. running routines so we don't get concurrent routines
            StopAllCoroutines();
    
            isHitByRay = true;
    
            // get point and direction relative to this object
            incomingHitPoint = transform.InverseTransformPoint(hitPoint);
            incomingHitDirection = transform.InverseTransformDirection(hitDirection);
    
            // start the turn off routine
            StartCoroutine(TurnOffAfterDelay());
        }
    
        // after the given delay turn off the raycast
        private IEnumerator TurnOffAfterDelay()
        {
            yield return new WaitForSeconds(turnOffDelay);
    
            isHitByRay = false;
        }
    }
