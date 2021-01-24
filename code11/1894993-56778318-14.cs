    public class CubeController : MonoBehaviour
    {
        public Cube Cube;
    
        private void Awake()
        {
            // Initial setup
            Cube.Reset();
        }
    
        private void Update()
        {
            var multiplier = 90;
    
            if (Input.GetKey(KeyCode.LeftShift))
            {
                multiplier = -90;
            }
    
            if (Input.GetKeyDown(KeyCode.X))
            {
                Cube.Rotation += Vector3Int.right * multiplier;
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                Cube.Rotation += Vector3Int.up * multiplier;
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                Cube.Rotation += new Vector3Int(0, 0, 1) * multiplier;
            }
        }
    }
    
