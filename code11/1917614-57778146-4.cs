    [RequireComponent(typeof(Image))]
    public class Example : MonoBehaviour
    {
        // your texture e.g. from a public field via the inspector
        public Texture2D texture;
    
        // define which pixel coordinates to use for this sprite also via the inspector
        public Rect pixelCoordinates;
    
        private void Start()
        {
            var newSprite = Sprite.Create(texture, pixelCoordinates, Vector2.one / 2f);
    
            GetComponent<Image>().sprite = newSprite;
        }
    
        // called everytime something is changed in the Inspector
        private void OnValidate()
        {
            if (!texture)
            {
                pixelCoordinates = new Rect();
                return;
            }
    
            // reset to valid rect values
            pixelCoordinates.x = Mathf.Clamp(pixelCoordinates.x, 0, texture.width);
            pixelCoordinates.y = Mathf.Clamp(pixelCoordinates.y, 0, texture.height);
            pixelCoordinates.width = Mathf.Clamp(pixelCoordinates.width, 0, pixelCoordinates.x + texture.width);
            pixelCoordinates.height = Mathf.Clamp(pixelCoordinates.height, 0, pixelCoordinates.y + texture.height);
        }
    }
