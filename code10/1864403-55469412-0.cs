    public class Speed : MonoBehaviour
    {
        public static int movespeed = 1;
        public Vector3 userDirection = Vector3.right;
        
        public void Start()
        {
        }
    
        public void Update()
        {
            transform.Translate(userDirection * movespeed * Time.deltaTime); 
        }
    }
