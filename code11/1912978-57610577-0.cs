    public virtual ImageSource OneColorImage(Color color, (Color Color, int Size)? border = null, int size = 32)
    {
        const int dpi = 96;
        var pixelFormat = PixelFormats.Indexed8;
        var stride = CalculateStride(pixelFormat.BitsPerPixel, size);
        var pixels = new byte[size * stride];
        var colors = new List<Color> { color };
        if (border.HasValue)
        {
            var (borderColor, borderSize) = border.Value;
            // Add the border color to the palette.
            colors.Add(borderColor);
            Byte paintIndex = 1;
            // Avoid overflow
            borderSize = Math.Min(borderSize, size);
            // Top line
            Int32 end = stride * borderSize;
            for (Int32 i = 0; i < end; i++)
                pixels[i] = paintIndex;
            // Bottom line
            end = stride * size;
            for (Int32 i = stride * (size - borderSize); i < end; i++)
                pixels[i] = paintIndex;
            // left line
            Int32 lineStart = 0;
            for (Int32 y = 0; y < size; y++)
            {
                for (Int32 x = 0; x < borderSize; x++)
                    pixels[lineStart + x] = paintIndex;
                lineStart += stride;
            }
            // right line
            Int32 start = size - borderSize;
            lineStart = 0;
            for (Int32 y = 0; y < size; y++)
            {
                for (Int32 x = start; x < size; x++)
                    pixels[lineStart + x] = paintIndex;
                lineStart += stride;
            }
        }
        BitmapPalette palette = new BitmapPalette(colors);
        BitmapSource image = BitmapSource.Create(size, size, dpi, dpi, pixelFormat, palette, pixels, stride);
        return new CachedBitmap(image, BitmapCreateOptions.None, BitmapCacheOption.Default);
    }
