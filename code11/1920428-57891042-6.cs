    public class Tile : MonoBehaviour
    {
        // maybe not needed anymore
        public bool Current = false;
        public bool Selectable = false;
    
        public bool MouseOver = false;
        public bool Clicked = false;
    
        // Will be assigned by the GridMap script
        // so every tile will know it's own position
        // you could also assign this via the Inspector
        // but maybe a lot overhead for 36 tiles ;)
        public Vector2Int TilePosition;
    
        // The player will register itself here
        // you could even already reference this via the Inspector
        // select all tiles and simply drag the player object here
        public GetPlayerPosition getPlayerPosition;
    
        // would even be better to already reference this via the Inspector
        // but maybe a bit overhead for 36 tiles 
        // except this is a prefab (what it probably should be ;) )
        [SerializeField] private Renderer renderer;
    
        private void Awake ()
        {
            // do this only once
            if(!renderer) renderer = GetComponent<Renderer>();
        }
        private void OnMouseEnter()
        {
            // do this only once .. no need to do it every frame
            MouseOver = true;
            renderer.material.color = Color.red;
        }
        private void OnMouseOver()
        {
            // skip further API calls if already Clicked
            if(Clicked) return;
            if (Input.GetMouseButton(0))
            {
                Clicked = true;
                renderer.material.color = Color.green;
           }
        }
        private void OnMouseExit()
        {
            MouseOver = false;
            Clicked = false;
            renderer.material.color = Color.white;
        }
    
        private void OnTriggerEnter(Collider other)
        {
            // do all these only once .. no need to do it every frame
            if(other.tag != "Player") return;
     
            renderer.material.color = Color.magenta;
            // Tell the player it's current position
            playerPosition.GridPosition = TilePosition;
            // probably not needed anymore
            Current = true;
        }
    
        private void OnTriggerExit(Collider other)
        {
            if(other.tag != "Player") return;
            renderer.material.color = Color.white;
            // probably not needed anymore
            Current = false;
        }
    }
