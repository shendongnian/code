    public static class Texture2DExtensions
    {
        public static void CropAroundCenter(this Texture2D input, Vector2Int newSize)
        {
            if(input.width < newSize.x || input.height < newSize.y)
            {
                Debug.LogError("You can't cut out an area of an image which is bigger than the image itself!");
                return;
            }
    
            // get center of input texture
            var center = new Vector2Int(input.width / 2, input.height / 2);
    
            // Get pixels around center
            // Get Pixels starts width 0,0 in the bottom left corner
            // so as the name says, center.x,center.y would get the pixel in the center
            // we want to start getting pixels from center - half of the newSize 
            //
            // than from starting there we want to read newSize pixels in both dimensions
            var pixels = input.GetPixels(center.x - newSize.x / 2, center.y - newSize.y / 2, newSize.x, newSize.y, 0);
    
            // Create a new texture with newSize
            input = new Texture2D(newSize.x, newSize.y);
           
            input.SetPixels(pixels);
        } 
    }
