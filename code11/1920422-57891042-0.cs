    public class Tile : MonoBehaviour
    {
        ...
    
        // Is set by the GridMap script
        // So every time will know it's own position
        public Vector2Int TilePosition;
    
        // The player will register itself here
        public GetPlayerPosition playerPosition;
    
        [SerializeField] private Renderer renderer;
    
        private void Awake ()
        {
            ...
            
            if(!renderer) renderer = GetComponent<Renderer>();
        }
    
        void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag != "Player") return;
    
            playerPosition.PlayerPosition = TilePosition;
        }
    
        void OnTriggerExit()
        {
            if(other.gameObject.tag != "Player") continue;
        }
    }
