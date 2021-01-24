    public class Tile : MonoBehaviour
    {
        public bool Current = false;
        public bool Selectable = false;
    
        public bool MouseOver = false;
        public bool Clicked = false;
    
        // Is set by the GridMap script
        // So every tile will know it's own position
        public Vector2Int TilePosition;
    
        // The player will register itself here
        // you could even already reference this via the Inspector
        public GetPlayerPosition getPlayerPosition;
    
        // would even be better to already reference this via the Inspector
        [SerializeField] private Renderer renderer;
    
        private void Awake ()
        {
            if(!renderer) renderer = GetComponent<Renderer>();
        }
        private void OnMouseEnter()
        {
            MouseOver = true;
            renderer.material.color = Color.red;
        }
        private void OnMouseOver()
        {
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
            if(other.tag != "Player") return;
     
            renderer.material.color = Color.magenta;
            playerPosition.PlayerPosition = TilePosition;
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
