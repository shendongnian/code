    System.Drawing.Image FullsizeImage = System.Drawing.Image.FromFile(originalFile);
    
    // Create a bitmap that's NewWidth x NewHeight
    Bitmap bmp = new Bitmap(NewWidth, NewHeight, PixelFormat.Format24bppRgb);
    
    // Get a Graphics object for that image and draw the original image into it
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.DrawImage(FullsizeImage, 0, 0, NewWidth, NewHeight);
    }
    
    // you now have a 24bpp thumbnail image
