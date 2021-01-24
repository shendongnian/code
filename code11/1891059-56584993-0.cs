    public class SinusWave : MonoBehaviour
    {
        public Vector3 initalPosition;
        public int pointCount = 10;
        public LineRenderer line;
        private Vector3 secondPosition;
        private Vector3[] points;
        private float segmentWidth;
    
        private void Awake()
        {
            line = GetComponent<LineRenderer>();
            line.positionCount = pointCount;
            // tell the linerenderer to use the local 
            // transform space for the point coorindates
            line.useWorldSpace = false;
    
            points = new Vector3[pointCount];
        }
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Camera.main.ScreenToWorldPoint needs a value in Z
                // for the distance to camera
                secondPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - Vector3.forward * Camera.main.transform.position.z);
                secondPosition.z = 0;
    
                var dir = secondPosition - initalPosition;
    
                segmentWidth = Vector3.Distance(initalPosition, secondPosition) / pointCount;
    
                // get the difference between the current transform.right
                // and the direction
                var angledifference = Vector3.SignedAngle(transform.right, dir, Vector3.forward);
                // and rotate the linerenderer transform by that angle
                // so the result will be that it's transform.right
                // points now towards the clicked position
                transform.Rotate(Vector3.forward * angledifference, Space.World);
            }
    
            for (var i = 0; i < points.Length; ++i)
            {
                float x = segmentWidth * i;
                float y = Mathf.Sin(x * Time.time);
                points[i] = new Vector3(x, y, 0);
            }
            line.SetPositions(points);
        }
    }
    
