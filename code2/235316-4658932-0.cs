    public System.Drawing.Image CreateThumbnail(System.Drawing.Image image, Size thumbnailSize)
    {
        float scalingRatio = CalculateScalingRatio(image.Size, thumbnailSize);
        int scaledWidth = (int)Math.Round((float)image.Size.Width * scalingRatio);
        int scaledHeight = (int)Math.Round((float)image.Size.Height * scalingRatio);
        int scaledLeft = (thumbnailSize.Width - scaledWidth) / 2;
        int scaledTop = (thumbnailSize.Height - scaledHeight) / 2;
        // For portrait mode, adjust the vertical top of the crop area so that we get more of the top area
        if (scaledWidth < scaledHeight && scaledHeight > thumbnailSize.Height)
        {
            scaledTop = (thumbnailSize.Height - scaledHeight) / 4;
        }
        Rectangle cropArea = new Rectangle(scaledLeft, scaledTop, scaledWidth, scaledHeight);
        System.Drawing.Image thumbnail = new Bitmap(thumbnailSize.Width, thumbnailSize.Height);
        using (Graphics thumbnailGraphics = Graphics.FromImage(thumbnail))
        {
            thumbnailGraphics.CompositingQuality = CompositingQuality.HighQuality;
            thumbnailGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            thumbnailGraphics.SmoothingMode = SmoothingMode.HighQuality;
            thumbnailGraphics.DrawImage(image, cropArea);
        }
        return thumbnail;
    }
    private float CalculateScalingRatio(Size originalSize, Size targetSize)
    {
        float originalAspectRatio = (float)originalSize.Width / (float)originalSize.Height;
        float targetAspectRatio = (float)targetSize.Width / (float)targetSize.Height;
        float scalingRatio = 0;
        if (targetAspectRatio >= originalAspectRatio)
        {
            scalingRatio = (float)targetSize.Width / (float)originalSize.Width;
        }
        else
        {
            scalingRatio = (float)targetSize.Height / (float)originalSize.Height;
        }
        return scalingRatio;
    }
