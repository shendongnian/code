    public class StickToTopLeft : MonoBehaviour
    {
        private Camera camera;
    
        public Vector2 PixelOffsetFromTopLeft = Vector2.zero;
    
        private void Start()
        {
            camera = Camera.main;
        }
    
        // Update is called once per frame
        private void Update()
        {
            var spawnpos = new Vector2(0 + PixelOffsetFromTopLeft.x, Screen.height - PixelOffsetFromTopLeft.y);
    
            // This time simply stay at the current distance to camera
            transform.position = camera.ScreenToWorldPoint(new Vector3(spawnpos.x, spawnpos.y, Vector3.Distance(camera.transform.position, transform.position)));
        }
    }
