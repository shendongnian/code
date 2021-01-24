    public class Mover: MonoBehaviour
    {
        public Vector3 destination;
        public Vector3 rate;
    
        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, rate * Time.deltaTime);
        }
    }
