    UIImage GenerateImage ()
    {
        UIGraphics.BeginImageContext (new RectangleF (0, 0, 100, 100));
        var ctx = UIGraphics.GetCurrentContext ();
        // Draw into the ctx anything you want.
        var image = UIGraphics.GetImageFromCurrentImageContext ();
        UIGraphics.EndImageContext ();
        return image;
    }
