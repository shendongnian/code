    public class ring : MonoBehaviour
    {
        //These are value types they have a default value
        public bool locked, resting;// bool default value is false
        private float startX, startY, deltaX, deltaY; // float is zero
        private Vector3 mousePos, beforeDrag;// Vector3 is Vector3.zero
        // This does not have a "default" value cos this is a reference type
        private List<GameObject> pegs = new List<GameObject>();
    
        // Start is called before the first frame update
        void Start()
        {
            startX = transform.position.x;
            startY = transform.position.y;
            locked = false;
            pegs.Add(GameObject.Find("PegA"));
            pegs.Add(GameObject.Find("PegB"));
            pegs.Add(GameObject.Find("PegC"));
        }
    }
