    public class HorizontalMovement : MonoBehaviour
    {
        public int speed;
    
        // Use this for initialization
        private void Start()
        {
            speed = 3;
        }
    
        // Update is called once per frame
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate((Vector3.left) * Time.deltaTime * 60);
            }
    
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate((transform.position + new Vector3(1, 0, 0)) * Time.deltaTime * 60);
            }
    
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
