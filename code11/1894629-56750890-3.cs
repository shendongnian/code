    public class GetCurves : MonoBehaviour
    {
        public GameObject A;
        public GameObject B;
    
        public int amount;
        public float moveSpeed;
    
        private List<Vector3> positions = new List<Vector3>();
        private Transform sphere;
        private int currentIndex = 0;
        private bool movingForward = true;
    
        private void Start()
        {
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
            sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    
            GeneratePositions(A.transform.position, B.transform.position, amount);
    
            sphere.position = positions[0];
        }
    
        private void GeneratePositions(Vector3 posA, Vector3 posB, int numberOfObjects)
        {
            // get circle center and radius
            var radius = Vector3.Distance(posA, posB) / 2f;
            var centerPos = (posA + posB) / 2f;
    
            // get a rotation that looks in the direction
            // posA -> posB
            var centerDirection = Quaternion.LookRotation((posB - posA).normalized);
    
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
        }
    
        private void Update()
        {
            if (positions == null || positions.Count == 0) return;
    
            // == for Vectors works with precision of 0.00001
            // if you need a better precision instead use
            //if(Mathf.Approximately(Vector3.Distance(sphere.position, positions[currentIndex]), 0f))
            if (sphere.position != positions[currentIndex])
            {
                sphere.position = Vector3.MoveTowards(sphere.transform.position, positions[currentIndex], moveSpeed * Time.deltaTime);
    
                return;
            }
    
            // once the position is reached select the next index
            if (movingForward)
            {
                if (currentIndex + 1 < positions.Count)
                {
                    currentIndex++;
                }
                else if (currentIndex + 1 >= positions.Count)
                {
                    currentIndex--;
                    movingForward = false;
                }
            }
            else
            {
                if (currentIndex - 1 >= 0)
                {
                    currentIndex--;
                }
                else
                {
                    currentIndex++;
                    movingForward = true;
                }
            }
        }
    }
