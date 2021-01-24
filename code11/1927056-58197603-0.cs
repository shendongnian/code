    public class movingWorldController : MonoBehaviour
    {
        public float movementSpeed = 5f;
        void FixedUpdate()
        {
            transform.position = transform.position + new Vector3(0, 0, movementSpeed * Time.deltaTime);
        }
    }
