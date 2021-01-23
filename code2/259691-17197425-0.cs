    private Size ResizeFit(Size originalSize, Size maxSize)
        {
            var widthAspect = (double)originalSize.Width / (double)maxSize.Width;
            var heightAspect = (double)originalSize.Height / (double)maxSize.Height;
            var maxAspectRatio = Math.Max(widthAspect, heightAspect);
            if (maxAspectRatio <= 1)
                return originalSize;
            return new Size((int)(originalSize.Width/maxAspectRatio), (int)(originalSize.Height/maxAspectRatio));
        }
