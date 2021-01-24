    // on the spawned object
    public class SpriteController : NetworkBehaviour
    {
        // Also good if you reference this already in the Inspector
        [SerializeField] private SpriteRenderer spriteRenderer;
        // Configured via the Inspector befrorehand
        public List<Sprite> Sprites;
    
        // Whenever this is changed on the Server
        // the change is automatically submitted to all clients
        // by using the "hook" it calls the OnSpriteIndexChanged and passes
        // the new value in as parameter
        [SyncVar(hook = nameof(OnSpriteIndexChanged))] public int SpriteIndex;
        // Will be called everytime the index is changed on the server
        [ClientCallback]
        private void OnSpriteIndexChanged(int newIndex)
        {
            // First when using a hook you have to explicitly apply the changed value at some point
            SpriteIndex = newIndex;
            if (!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Sprites[SpriteIndex];
        }
    }
