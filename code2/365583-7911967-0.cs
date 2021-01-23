    // set the light and dark overlay colors
    Color c1 = Color.FromArgb(80, Color.Silver);
    Color c2 = Color.FromArgb(80, Color.DarkGray);
    
    // set up the tile size - this will be 8x8 pixels, with each light/dark square being 4x4 pixels
    int length = 8;
    int halfLength = length / 2;
    
    using (Bitmap overlay = new Bitmap(length, length, PixelFormat.Format32bppArgb))
    {
        // draw the overlay - this will be a 2 x 2 grid of squares,
        // alternating between colors c1 and c2
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < length; y++)
            {
                if ((x < halfLength && y < halfLength) || (x >= halfLength && y >= halfLength)) 
                    overlay.SetPixel(x, y, c1);
                else 
                    overlay.SetPixel(x, y, c2);
            }
        }
    
        // open the source image
        using (Image image = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\homers_brain.jpg"))
        using (Graphics graphics = Graphics.FromImage(image))
        {
            // create a brush from the overlay image, draw over the source image and save to a new image
            using (Brush overlayBrush = new TextureBrush(overlay))
            {
                graphics.FillRectangle(overlayBrush, new Rectangle(new Point(0, 0), image.Size));
                image.Save(@"C:\Users\Public\Pictures\Sample Pictures\homers_brain_overlay.jpg");
            }
        }
    }
