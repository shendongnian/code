    Image GetClipboardImage()
    {
        if (Clipboard.ContainsImage())
        {
             Image = Clipboard.GetImage();
            Clipboard.SetImage(replacementImage);
        }
        else
        {
        // add error handling
        }
    }
