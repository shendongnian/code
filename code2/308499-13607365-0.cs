    // Get the source file and create a result bitmap of the same size
    using (var source = Image.FromFile("old colour image.png", false))
    using (var result = new Bitmap(source.Width, source.Height))
    {
        // Build a colour map of old to new colour
        ColorMap[] colorMap = BuildArrayOfOldAndNewColours();
    
        // Build image attributes with the map
        var attr = new ImageAttributes();
        attr.SetRemapTable(colorMap);
    
        // Draw a rectangle the same size as the image
        var rect = new Rectangle(0, 0, source.Width, source.Height);
    
        // Draw the old image into the new one with one colour mapped to the other
        var g = Graphics.FromImage(result);
        g.DrawImage(source, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, attr);
    
        result.Save("new colour image.png");
    }
