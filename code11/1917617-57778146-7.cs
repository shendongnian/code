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
                for(var i = 0; i < pixelCoordinates.Count; i++)
                {
                    pixelCoordinates[i] = new Rect();
                }
                return;
            }
    
            for (var i = 0; i < pixelCoordinates.Count; i++)
            {
                // reset to valid rect values
                var rect = pixelCoordinates[i];
                rect.x = Mathf.Clamp(pixelCoordinates[i].x, 0, texture.width);
                rect.y = Mathf.Clamp(pixelCoordinates[i].y, 0, texture.height);
                rect.width = Mathf.Clamp(pixelCoordinates[i].width, 0, pixelCoordinates[i].x + texture.width);
                rect.height = Mathf.Clamp(pixelCoordinates[i].height, 0, pixelCoordinates[i].y + texture.height);
                pixelCoordinates[i] = rect;
            }
        }
    }
