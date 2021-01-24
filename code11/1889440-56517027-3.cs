    public class PlayerMov : MonoBehaviour
    {
        public bool down = true;
        public float moveSpeed = 1;
        void Update()
        {
            if (Input.GetKey("space"))
            {
                down = !down;
            }
            Vector3 directionVector = (down == true) ? Vector3.down : Vector3.up;
            transform.position += directionVector * moveSpeed * Time.deltaTime;
        }
    }
