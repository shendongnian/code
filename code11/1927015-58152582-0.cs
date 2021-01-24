    private double GetTransparentPixelPercentage(BitmapSource bitmap)
    {
        if (bitmap.Format != PixelFormats.Bgra32)
        {
            bitmap = new FormatConvertedBitmap(bitmap, PixelFormats.Bgra32, null, 0);
        }
        var stride = 4 * bitmap.PixelWidth;
        var pixelCount = stride * bitmap.PixelHeight;
        var pixels = new byte[pixelCount];
        bitmap.CopyPixels(pixels, stride, 0);
        var transparentPixelCount = 0;
        for (int i = 0; i < pixelCount; i += 4)
        {
            if (pixels[i + 3] == 0) // check alpha value
            {
                transparentPixelCount++;
            }
        }
        return (double)transparentPixelCount / pixelCount;
    }
