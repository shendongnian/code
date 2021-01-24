    public static class Texture2DExtensions
    {
        public static void FlipVertically(this Texture2D texture)
        {
            var pixels = texture.GetPixels();
            var flippedPixels = new Color[pixels.Length];
    
            // These for loops are for running through each individual pixel and 
            // write them with inverted Y coordinates into the flippedPixels
            for (var x = 0; x < texture.width; x++)
            {
                for (var y = 0; y < texture.height; y++)
                {
                    var pixelIndex = x + y * texture.width;
                    var flippedIndex = x  + (texture.height - 1 - y) * texture.width;
    
                    flippedPixels[flippedIndex] = pixels[pixelIndex];
                }
            }
    
            texture.SetPixels(flippedPixels);
            texture.Apply();
        }
    }
