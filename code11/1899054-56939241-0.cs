    // Read first frame of gif image
    using (MagickImage image = new MagickImage("Snakeware.gif"))
    {
        // Save frame as jpg
        image.Write("Snakeware.jpg");
    }
    
    // Write to stream
    MagickReadSettings settings = new MagickReadSettings();
    // Tells the xc: reader the image to create should be 800x600
    settings.Width = 800;
    settings.Height = 600;
    
    using (MemoryStream memStream = new MemoryStream())
    {
        // Create image that is completely purple and 800x600
        using (MagickImage image = new MagickImage("xc:purple", settings))
        {
            // Sets the output format to png
            image.Format = MagickFormat.Png;
            // Write the image to the memorystream
            image.Write(memStream);
        }
    }
    
    // Read image from file
    using (MagickImage image = new MagickImage("Snakeware.png"))
    {
        // Sets the output format to jpeg
        image.Format = MagickFormat.Jpeg;
        // Create byte array that contains a jpeg file
        byte[] data = image.ToByteArray();
    }
