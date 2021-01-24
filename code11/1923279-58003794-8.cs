    // on the spawned object
    public class SpriteController : NetworkBehaviour
    {
        // Configured via the Inspector befrorehand
        public List<Sprite> Sprites;
    
        // Whenever this is changed on the Server
        // the change is automatically submitted to all clients
        // Is also done before Start is called so we can rely on it there
        [SyncVar] public int SpriteIndex;
    
        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[SpriteIndex];
        }
    }
