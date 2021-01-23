    // Load the original image
    Bitmap bmp = new Bitmap("filename.bmp");
    
    // Create a rectangle for the entire bitmap
    RectangleF rectf = new RectangleF(0, 0, bmp.Width, bmp.Height);
    
    // Create graphic object that will draw onto the bitmap
    Graphics g = Graphics.FromImage(bmp);
    
    // ------------------------------------------
    // Ensure the best possible quality rendering
    // ------------------------------------------
    // The smoothing mode specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing). One exception is that path gradient brushes do not obey the smoothing mode. Areas filled using a PathGradientBrush are rendered the same way (aliased) regardless of the SmoothingMode property.
    g.SmoothingMode = SmoothingMode.AntiAlias;
    // The interpolation mode determines how intermediate values between two endpoints are calculated.
    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    // Use this property to specify either higher quality, slower rendering, or lower quality, faster rendering of the contents of this Graphics object.
    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    // This one is important
    g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
    
    // Create string formatting options (used for alignment)
    StringFormat format = new StringFormat()
    {
        Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center
    };
    
    // Draw the text onto the image
    g.DrawString("yourText", new Font("Tahoma",8), Brushes.Black, rectf, format);
    
    // Flush all graphics changes to the bitmap
    g.Flush();
    
    // Now save or use the bitmap
    image.Image = bmp;
