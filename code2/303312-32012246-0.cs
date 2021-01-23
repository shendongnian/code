    // Load the original image
    Bitmap bmp = new Bitmap("filename.bmp");
    
    // Create a rectangle for the entire bitmap
    RectangleF rectf = new RectangleF(0, 0, bmp.Width, bmp.Height);
    
    // Create graphic object that will draw onto the bitmap
    Graphics g = Graphics.FromImage(bmp);
    
    // Ensure the best possible quality rendering
    g.SmoothingMode = SmoothingMode.AntiAlias;
    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;  // This one is important
    
    // Create string formatting options (used for alignment)
    StringFormat format = new StringFormat()
    {
        Alignment = StringAlighment.Center,
        LineAlignment = StringAlighment.Center
    });
    
    // Draw the text onto the image
    g.DrawString("yourText", new Font("Tahoma",8), Brushes.Black, rectf, format);
    
    // Flush all graphics changes to the bitmap
    g.Flush();
    
    // Now save or use the bitmap
    image.Image = bmp;
