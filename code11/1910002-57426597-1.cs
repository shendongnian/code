    using UnityEngine;
    
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class PlaneController : MonoBehaviour
    {
        public Transform target1;
        public Transform target2;
        public Transform target3;
    
        private MeshFilter meshFilter;
        private Mesh mesh;
        private Vector3[] vertices;
    
        private void Awake()
        {
            meshFilter = GetComponent<MeshFilter>();
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
    
        // Update is called once per frame
        void Update()
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
    }
