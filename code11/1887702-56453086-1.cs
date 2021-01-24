    public class PlatformMoving : MonoBehaviour
    {
        public float speed = 1.5f; //How fast the platforms are moving
    
        // use this for initialization
        void Start()
        {
    
        }
    
        // Update is called once per frame
        void Update()
        {
    
            // Every frame we look at the position of the ground and it is moved to the left
            transform.position = transform.position - (Vector3.right * speed * Time.deltaTime);
    
            // If the position of the ground is off the left of the screen
            if (transform.position.x <= -13.05f)
            {
                // Move it to the far right of the screen
                transform.position = transform.position + (Vector3.right * 53.3f);
                // Increase speed here
                // speed += x;
            }
        }
    }
