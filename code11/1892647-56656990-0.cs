        public class PlaneController : MonoBehaviour {
        public int moveSpeed;
        public TextAsset coordinates;
        List<Vector3> Points;
        int currentPointIndex = 0;
        void Start() {
            Points = new List<Vector3>();
    
            var pointsArray = coordinates.text.Split(new char[] { '\n' });
            for (int i = 1; i < pointsArray.Length - 1; i++)
            {
                var dataRow = pointsArray[i].Split(new char[] { ',' });
                Points.Add(new Vector3(float.Parse(dataRow[0]), float.Parse(dataRow[1]), float.Parse(dataRow[2])));
            }
        }
    
        void Update() {
            if (transform.position == Points[currentPointIndex])
            {
                if (currentPointIndex < Points.Count - 1)
                {
                    currentPointIndex++;
                }
                else
                {
                    currentPointIndex = 0;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.localPosition, Points[currentPointIndex], Time.deltaTime * moveSpeed);
            }
        }
    }
