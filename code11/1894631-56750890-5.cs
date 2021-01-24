    public class MoveBetweenPoints : MonoBehaviour
    {
        public List<Vector3> positions = new List<Vector3>();
        public float moveSpeed;
       
        privtae bool movingForward = true;
        private int currentIndex = 0;
        private void Update()
        {
            if (positions == null || positions.Count == 0) return;
    
            // == for Vectors works with precision of 0.00001
            // if you need a better precision instead use
            //if(Mathf.Approximately(Vector3.Distance(sphere.position, positions[currentIndex]), 0f))
            if (sphere.position != positions[currentIndex])
            {
                transform.position = Vector3.MoveTowards(transform.position, positions[currentIndex], moveSpeed * Time.deltaTime);
    
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
