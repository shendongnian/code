    image.Range.Select();
    image.Application.Selection.Copy();
    
    System.Drawing.Image clipboardImage = null;
    if (Clipboard.ContainsImage())
    {
         clipboardImage = Clipboard.GetImage();
    
         //do something with the image on the clipboard
    }
