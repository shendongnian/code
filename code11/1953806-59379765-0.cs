    // crop the image, without resizing
    private UIImage CropImage(UIImage sourceImage, int crop_x, int crop_y, int width, int height)
    {
        var imgSize = sourceImage.Size;
        UIGraphics.BeginImageContext(new SizeF(width, height));
        var context = UIGraphics.GetCurrentContext();
        var clippedRect = new RectangleF(0, 0, width, height);
        context.ClipToRect(clippedRect);
        var drawRect = new RectangleF(-crop_x, -crop_y, imgSize.Width, imgSize.Height);
        sourceImage.Draw(drawRect);
        var modifiedImage = UIGraphics.GetImageFromCurrentImageContext();
        UIGraphics.EndImageContext();
        return modifiedImage;
    }
