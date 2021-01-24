    public class Example : MonoBehaviour
    {
        // your texture e.g. from a public field via the inspector
        public Texture2D texture;
    
        // define which pixel coordinates to use for this sprite also via the inspector
        public List<Rect> pixelCoordinates = new List<Rect>();
        // OUTPUT
        public List<Sprite> resultSprites = new List<Sprite>();
    
        private void Start()
        {
            foreach(var coordinates in pixelCoordinates)
            {
                var newSprite = Sprite.Create(texture, coordinates, Vector2.one / 2f);
    
                resultSprites.Add(newSprite);
            }
        }
    
        // called everytime something is changed in the Inspector
        private void OnValidate()
        {
            if (!texture)
            {
                foreach(var coordinates in pixelCoordinates) coordinates = new Rect();
                return;
            }
    
            foreach(var coordinates in pixelCoordinates)
            {
                // reset to valid rect values
                coordinates.x = Mathf.Clamp(pixelCoordinates.x, 0, texture.width);
                coordinates.y = Mathf.Clamp(pixelCoordinates.y, 0, texture.height);
                coordinates.width = Mathf.Clamp(pixelCoordinates.width, 0, pixelCoordinates.x + texture.width);
                coordinates.height = Mathf.Clamp(pixelCoordinates.height, 0, pixelCoordinates.y + texture.height);
            }
        }
    }
