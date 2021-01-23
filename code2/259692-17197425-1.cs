    private Size ResizeFit(Size originalSize, Size maxSize)
    {
        var widthRatio = (double)maxSize.Width / (double)originalSize.Width;
        var heightRatio = (double) maxSize.Height/(double) originalSize.Height;
        var minAspectRatio = Math.Min(widthRatio, heightRatio);
        if (minAspectRatio > 1)
            return originalSize;
        return new Size((int)(originalSize.Width*minAspectRatio), (int)(originalSize.Height*minAspectRatio));
    }
