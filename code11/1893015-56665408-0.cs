    public class PositionsManager : MonoBehaviour
    {
        // I know .. singleton pattern .. buuu
        // but that's the fastest way to prototype ;)
        public static PositionsManager Singleton;
    
        private void Awake()
        {
            transform.position = Vector3.zero;
            transform.eulerAngles = new Vector3(0, 45, 0);
    
            Singleton = this;
        }
    
        public Vector2Int GetDistance(Transform from, Transform to)
        {
            var localPosFrom = transform.InverseTransformPoint(from.position);
            var localPosTo = transform.InverseTransformPoint(to.position);
    
            // Now you can simply get the actual position distance and return 
            // them as vector2 so you can even still see the components
            // seperately
            var difference = localPosTo - localPosFrom;
    
            // since you are using X-Z not X-Y you have to convert the vector "manually"
            return new Vector2Int(Mathf.RoundToInt(difference.x), Mathf.RoundToInt(difference.z));
        }
    }
