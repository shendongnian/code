    public class Spawner : MonoBehaviour
    {
        public GameObject Prefab;
    
        public Vector2 PixelOffsetFromTopLeft = Vector2.zero;
    
        private GameObject spawnedObject;
        private Camera camera;
    
        private void Start()
        {
            camera = Camera.main;
        }
    
        private void Update()
        {
            if (Input.anyKeyDown)
            {
                // you don't need this I just didn't want to mess up the scene
                // so I just destroy the last spawned object before placing a new one
                if (spawnedObject)
                {
                    Destroy(spawnedObject);
                }
    
                // Top Left pixel is at 
                // x = 0
                // y = Screen height
    
                // and than add the desired offset
                var spawnpos = new Vector2(0 + PixelOffsetFromTopLeft.x, Screen.height - PixelOffsetFromTopLeft.y);
    
                // as z we want a given distance to camera (e.g. 2 Units in front)
                spawnedObject = Instantiate(Prefab, camera.ScreenToWorldPoint(new Vector3(spawnpos.x, spawnpos.y, 2f)), Quaternion.identity);
            }
        }
    }
