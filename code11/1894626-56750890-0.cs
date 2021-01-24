    public class GetCurves : MonoBehaviour
    {
    
        public GameObject A;
        public GameObject B;
        public int amount;
        public float moveSpeed;
    
        [ContextMenu("PlaceSpheres()")]
        public void Start()
        {
            PlaceSpheres(A.transform.position, B.transform.position, amount);
        }
    
        public void PlaceSpheres(Vector3 posA, Vector3 posB, int numberOfObjects)
        {
            // get circle center and radius
            var radius = Vector3.Distance(posA, posB) / 2f;
            var centerPos = (posA + posB) / 2f;
    
            // get a rotation that looks in the direction
            // posA -> posB
            var centerDirection = Quaternion.LookRotation((posB - posA).normalized);
            // store them in a list this time
            var List<Vector3> positions = new List<Vector3>();
    
            for (var i = 0; i < numberOfObjects; i++)
            {
    
                var angle = Mathf.PI * (i+1) / (numberOfObjects + 1); //180 degrees
                var x = Mathf.Sin(angle) * radius;
                var z = Mathf.Cos(angle) * radius;
                var pos = new Vector3(x, 0, z);
                // Rotate the pos vector according to the centerDirection
                pos = centerDirection * pos;
    
                positions.Add(pos);
            }
            // start the movement with given positions
            // using a Coroutine
            StartCoroutine(MoveBetweenPoints(positions));
        }
    
        private IEnumerator MoveBetweenPoints(List<Vector3> positions)
        {
            if(positions == null || positions.Count == 0) yield break;
            var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = centerPos + pos;
            sphere.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
    
            var currentIndex = 0;
            var movingForward = true;
    
            while(true)
            {
                while(sphere.position != positions[currentIndex])
                {
                    spehere.transform.MoveTowards(sphere.transform.position, positions[currentIndex], moveSpeed * Time.deltaTime);
    
                    yield return null;
                }
    
                // once the position is reached select the next one
                if(movingForawrd && currentIndex + 1 < positions.Count)
                {
                    currentIndex++;
                }
                else if ( movingForward && currentindex + 1 => positions.Count)
                {
                    currentIndex--;
                    movingForward = false;
                }
                else if (!movingForward && currentIndex -1 > 0)
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
