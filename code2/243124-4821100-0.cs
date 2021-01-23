    static Bitmap TrimBitmap(Bitmap source)
    {
        Rectangle srcRect = default(Rectangle);
        BitmapData data = null;
        try
        {
            data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] buffer = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
            int xMin = int.MaxValue;
            int xMax = 0;
            int yMin = int.MaxValue;
            int yMax = 0;
            for (int y = 0; y < data.Height; y++)
            {
                for (int x = 0; x < data.Width; x++)
                {
                    byte alpha = buffer[y * data.Stride + 4 * x + 3];
                    if (alpha != 0)
                    {
                        if (x < xMin) xMin = x;
                        if (x > xMax) xMax = x;
                        if (y < yMin) yMin = y;
                        if (y > yMax) yMax = y;
                    }
                }
            }
            if (xMax < xMin || yMax < yMin)
            {
                // Image is empty...
                return null;
            }
            srcRect = Rectangle.FromLTRB(xMin, yMin, xMax, yMax);
        }
        finally
        {
            if (data != null)
                source.UnlockBits(data);
        }
        
        Bitmap dest = new Bitmap(srcRect.Width, srcRect.Height);
        Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
        using (Graphics graphics = Graphics.FromImage(dest))
        {
            graphics.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
        }
        return dest;
    }
