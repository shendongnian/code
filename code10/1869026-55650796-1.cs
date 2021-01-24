    public class LineRendererController : MonoBehaviour
    {
        private LineRenderer lineRenderer;
        // Use this for initialization
        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 5;
            lineRenderer.useWorldSpace = false;
            var points = new Vector3[5];
            points[0] = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
            points[0].z = 0;
            points[1] = Camera.main.WorldToScreenPoint(new Vector3(2, 0, 0));
            points[1].z = 0;
            points[2] = Camera.main.WorldToScreenPoint(new Vector3(2, -2, 0));
            points[2].z = 0;
            points[3] = Camera.main.WorldToScreenPoint(new Vector3(0, -2, 0));
            points[3].z = 0;
            // in order to close the frame at the end
            points[4] = points[0];
            lineRenderer.SetPositions(points);
        }
    }
    
