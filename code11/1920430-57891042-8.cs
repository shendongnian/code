    public class GetPlayerPosition : MonoBehaviour
    {
        // would be better if you already reference this via the Inspector
        [SerilaizeField] private GridMap map;
    
        // Will be assigned when entering a Tile
        public Vector2Int GridPosition;
    
        private void Awake()
        {
            if(!map) map = FindObjectOfType<GridMap>();
        }
    
        private void Start()
        {  
            // if you don't have to know the indices within the loop
            // you can iterate a multidimensional array simply via foreach
            // because internally it is actually saved and treated as flat array
            foreach (var tile in map.GridMatrix)
            {
                tile.playerPosition = this;               
            }
        }
    }
