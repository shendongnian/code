    // on the spawned object
    public class SpriteController : NetworkBehaviour
    {
        // Configured via the Inspector befrorehand
        public List<Sprite> Sprites;
    
        [SyncVar] public int SpriteIndex;
    
        private void Start()
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[SpriteIndex];
        }
    }
