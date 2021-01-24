    // ! UNCOMMENT THIS IF YOU RATHER WANT TO USE THE LINERENDERER !
    //#define USE_LINERENDERER
    using UnityEngine;
    using UnityEngine.UI;
    
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class PlaneController : MonoBehaviour
    {
        [Header("Input")]
    
        // Reference these in the Inspector
        public Transform target1;
        public Transform target2;
        public Transform target3;
        public Transform target4;
    
        [Space]
    
        public MeshFilter meshFilter;
    
        [Header("Output")]
        public float AngleOnPlane;
    
        public Text angleText;
        public float lineWith = 0.05f;
    
    #if USE_LINERENDERER
        public LineRenderer lineRenderer;
    #else
        public MeshRenderer cubeLine;
    #endif
    
        private Mesh mesh;
        private Vector3[] vertices;
        private Vector3 redLineDirection;
    
        // if using line renderer
        private Vector3[] positions = new Vector3[2];
    
        private void Start()
        {
            InitializePlaneMesh();
    
    #if USE_LINERENDERER
            InitializeLineRenderer();
    #endif
        }
    
        // Update is called once per frame
        private void Update()
        {
            // update the plane mesh
            UpdatePlaneMesh();
    
            // update the angle value
            UpdateAngle();
    #if USE_LINERENDERER
            // update the line either using the line renderer
            UpdateLineUsingLineRenderer();
    #else
            // update the line rather using a simple scaled cube instead
            UpdateLineUsingCube();
    #endif
        }
    
        private void InitializePlaneMesh()
        {
            if (!meshFilter) meshFilter = GetComponent<MeshFilter>();
    
            mesh = meshFilter.mesh;
    
            vertices = new Vector3[4];
    
            // Set the 4 triangles (front and backside)
            // using the 4 vertices
            var triangles = new int[3 * 4];
    
            // triangle 1 - ABC
            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;
            // triangle 2 - ACD
            triangles[3] = 0;
            triangles[4] = 2;
            triangles[5] = 3;
    
            // triangle 3 - BAC
            triangles[6] = 1;
            triangles[7] = 0;
            triangles[8] = 2;
            // triangle 4 - ADC
            triangles[9] = 0;
            triangles[10] = 3;
            triangles[11] = 2;
    
            mesh.vertices = vertices;
            mesh.triangles = triangles;
        }
    
    #if USE_LINERENDERER
        private void InitializeLineRenderer()
        {
            lineRenderer.positionCount = 2;
            lineRenderer.startWidth = lineWith;
            lineRenderer.endWidth = lineWith;
            lineRenderer.loop = false;
            lineRenderer.alignment = LineAlignment.View;
            lineRenderer.useWorldSpace = true;
        }
    #endif
    
        private void UpdatePlaneMesh()
        {
            // build triangles according to target positions
            vertices[0] = target1.position - transform.position; // A
            vertices[1] = target2.position - transform.position; // B
            vertices[2] = target3.position - transform.position; // C
    
            // D = A  + B->C
            vertices[3] = vertices[0] + (vertices[2] - vertices[1]);
    
            // update the mesh vertex positions
            mesh.vertices = vertices;
    
            // Has to be done in order to update the bounding box culling
            mesh.RecalculateBounds();
        }
    
        private void UpdateAngle()
        {
            // get the plane (green line/area)
            var plane = new Plane(target1.position, target2.position, target3.position);
    
            // get the red vector
            redLineDirection = target4.position - target1.position;
    
            // get difference
            var angle = Vector3.Angle(plane.normal, redLineDirection);
    
            // since the normal itself stands 90° on the plane
            AngleOnPlane = Mathf.Abs(90 - angle);
    
            // write the angle value to a UI Text element
            angleText.text = $"Impact Angle = {AngleOnPlane:F1}°";
    
            // move text to center of red line and a bit above it
            angleText.transform.position = (target1.position + target4.position) / 2f + Vector3.up * 0.1f;
    
            // make text always face the user (Billboard)
            // using Camera.main here is not efficient! Just for the demo
            angleText.transform.forward = Camera.main.transform.forward;
        }
    
    #if USE_LINERENDERER
        private void UpdateLineUsingLineRenderer()
        {
            positions[0] = target1.position;
            positions[1] = target4.position;
    
            lineRenderer.SetPositions(positions);
        }
    #else
        private void UpdateLineUsingCube()
        {
            // simply rotate the cube so it is facing in the line direction
            cubeLine.transform.forward = redLineDirection.normalized;
    
            // scale it to match both target positions with its ends
            cubeLine.transform.localScale = new Vector3(lineWith, lineWith, redLineDirection.magnitude);
    
            // and move it to the center between both targets
            cubeLine.transform.position = (target1.position + target4.position) / 2f;
        }
    #endif
    }
