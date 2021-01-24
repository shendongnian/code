        public class PlaneController : MonoBehaviour
        {
            public TextAsset coordinates;
            public int moveSpeed;
        
            string[] coordinatesArray;
            int currentPointIndex = 0;
            Vector3 destinationVector;
        
            void Start()
            {
                coordinatesArray = coordinates.text.Split(new char[] { '\n' });
            }
    
            void Update()
            {
                if (destinationVector == null || transform.position == destinationVector)
                {
                    currentPointIndex = currentPointIndex < coordinatesArray.Length - 1 ? currentPointIndex + 1 : 1;
                    if(!string.IsNullOrWhiteSpace(coordinatesArray[currentPointIndex]))
                    {
                        string[] xyz = coordinatesArray[currentPointIndex].Split(new char[] { ',' });
                        destinationVector = new Vector3(float.Parse(xyz[0]), float.Parse(xyz[1]), float.Parse(xyz[1]));
                    }
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.localPosition, destinationVector, Time.deltaTime * moveSpeed);
                }
            }
        }
