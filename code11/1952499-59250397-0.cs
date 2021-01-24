    public static Color GetDominantColor(this Bitmap bitmap, int startX, int startY, int width, int height) {
    
        var maxWidth = bitmap.Width;
        var maxHeight = bitmap.Height;
    
        //TODO: validate the region being requested
    
        //Used for tally
        int r = 0;
        int g = 0;
        int b = 0;
        int totalPixels = 0;
    
        for (int x = startX; x < (startX + width); x++) {
            for (int y = startY; y < (startY + height); y++) {
                Color c = bitmap.GetPixel(x, y);
    
                r += Convert.ToInt32(c.R);
                g += Convert.ToInt32(c.G);
                b += Convert.ToInt32(c.B);
    
                totalPixels++;
            }
        }
    
        r /= totalPixels;
        g /= totalPixels;
        b /= totalPixels;
    
        Color color = Color.FromArgb(255, (byte)r, (byte)g, (byte)b);
    
        return color;
    }
