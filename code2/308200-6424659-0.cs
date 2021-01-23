    int epsilon = 10;
    
    for (x = 0; x < image1.Width; ++x)
    {
        for (y = 0; y < image1.Height; ++y)
        {
            Color pixelColor = image1.GetPixel(x, y);
            redt = pixelColor.R;
            greent = pixelColor.G;
            bluet = pixelColor.B;
            
            if (Math.Abs(redt   - red)   <= epsilon &&
                Math.Abs(greent - green) <= epsilon &&
                Math.Abs(bluet  - blue)  <= epsilon)
            {
                ++ count;
            }
        }
    }
