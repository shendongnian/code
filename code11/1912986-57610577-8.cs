    public virtual ImageSource OneColorImage(Color color, (Color Color, int Size)? border = null, int size = 32)
    {
        const Int32 dpi = 96;
        Int32 stride = CalculateStride(8, size);
        Byte[] pixels = new byte[size * stride];
        List<Color> colors = new List<Color> { color };
        if (border.HasValue)
        {
            var (borderColor, borderSize) = border.Value;
            // Add the border color to the palette.
            colors.Add(borderColor);
            Byte paintIndex = 1;
            // Avoid overflow
            borderSize = Math.Min(borderSize, size);
            // Horizontal: just fill the whole block.
            // Top line
            Int32 end = stride * borderSize;
            for (Int32 i = 0; i < end; i++)
                pixels[i] = paintIndex;
            // Bottom line
            end = stride * size;
            for (Int32 i = stride * (size - borderSize); i < end; i++)
                pixels[i] = paintIndex;
            // Vertical: only process the space between the already filled top and bottom parts.
            // left line
            Int32 yEnd = size - borderSize;
            Int32 lineStart = borderSize * stride;
            for (Int32 y = borderSize; y < yEnd; y++)
            {
                for (Int32 x = 0; x < borderSize; x++)
                    pixels[lineStart + x] = paintIndex;
                lineStart += stride;
            }
            // right line
            Int32 start = size - borderSize;
            lineStart = borderSize * stride;
            for (Int32 y = borderSize; y < yEnd; y++)
            {
                for (Int32 x = start; x < size; x++)
                    pixels[lineStart + x] = paintIndex;
                lineStart += stride;
            }
        }
        BitmapPalette palette = new BitmapPalette(colors);
        BitmapSource image = BitmapSource.Create(size, size, dpi, dpi, PixelFormats.Indexed8, palette, pixels, stride);
        return new CachedBitmap(image, BitmapCreateOptions.None, BitmapCacheOption.Default);
    }
