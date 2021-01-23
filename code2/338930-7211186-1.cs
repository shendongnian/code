    Image GetClipboardImage()
    {
        if (Clipboard.ContainsImage())
        {
             return Clipboard.GetImage();
        }
        // add error handling
    }
