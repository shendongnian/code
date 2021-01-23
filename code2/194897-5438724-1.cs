    //Register the font once.
    BitmapFont.RegisterFont("Font.png", "Metrics.xml");
    //Draws the text to a new bitmap, font name is image name without extension.
    image.Source = BitmapFont.DrawFont(DateTime.Now.ToLongTimeString(), "Font");
    //Alternatively put these elements in a horizontal StackPanel, or ItemsControl
    //This doesn't create any new bitmaps and should be more efficient.
    //You could alter the method to transform each letter too.
    BitmapFont.GetElements(DateTime.Now.ToLongTimeString(), "Font");
