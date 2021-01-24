    public class GetCurves : MonoBehaviour
    {
        public GameObject A;
        public GameObject B;
    
        public int amount;
        public float moveSpeed;
    
        private void Start()
        {
            GeneratePositions(A.transform.position, B.transform.position, amount);
        }
    
        private void GeneratePositions(Vector3 posA, Vector3 posB, int numberOfObjects)
        {
            // get circle center and radius
            var radius = Vector3.Distance(posA, posB) / 2f;
            var centerPos = (posA + posB) / 2f;
    
            // get a rotation that looks in the direction
            // posA -> posB
            var centerDirection = Quaternion.LookRotation((posB - posA).normalized);
            List<Vector3> positions = new List<Vector3>();    
            for (var i = 0; i < numberOfObjects; i++)
            {
    
                var angle = Mathf.PI * (i + 1) / (numberOfObjects + 1); //180 degrees
                var x = Mathf.Sin(angle) * radius;
                var z = Mathf.Cos(angle) * radius;
                var pos = new Vector3(x, 0, z);
                // Rotate the pos vector according to the centerDirection
                pos = centerDirection * pos;
    
                // store them in a list this time
                positions.Add(centerPos + pos);
            }
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            var movement = sphere.AddComponent<MoveBetweenPoints>();
            movement.positions = positions;
            movement.moveSpeed = moveSpeed;
        }
