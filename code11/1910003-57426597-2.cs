    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    using UnityEngine;
    public class AngleChecker : MonoBehaviour
    {
        [Header("Input")]
    
        public Transform target1;
        public Transform target2;
        public Transform target3;
        public Transform target4;
    
        [Header("Output")]
        public float AngleOnPlane;
    
        private void Update()
        {
            AngleOnPlane = GetAngle();
        }
    
        private float GetAngle()
        {
            // get the plane (green line/area)
            var plane = new Plane(target1.position, target2.position, target3.position);
    
            // get the red vector
            var vector = target4.position - target1.position;
    
            // get difference
            var angle = Vector3.Angle(plane.normal, vector);
    
            // since the normal itself stands 90° on the plane
            return 90 - angle;
        }
    
    #if UNITY_EDITOR
        // ONLY FOR VISUALIZATION
        private void OnDrawGizmos()
        {
            // draw the plane
            var mesh = new Mesh
            {
                vertices = new[]
                {
                    target1.position,
                    target2.position,
                    target3.position,
                    target3.position + (target1.position - target2.position)
                },
                triangles = new[] {
                    0, 1, 2,
                    0, 2, 3,
                    1, 0, 2,
                    0, 3, 2
                }
            };
            mesh.RecalculateNormals();
            Gizmos.color = Color.white;
            Gizmos.DrawMesh(mesh);
            // draw the normal at target1
            var plane = new Plane(target1.position, target2.position, target3.position);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(target1.position, plane.normal);
            Handles.Label(target1.position + plane.normal, "plane normal");
            // draw the red vector
            Gizmos.color = Color.red;
            Gizmos.DrawLine(target1.position, target4.position);
            Handles.Label(target4.position , $"Angle to plane: {90 - Vector3.Angle(plane.normal, target4.position - target1.position)}");
        }
    #endif
    }
