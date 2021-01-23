    public static unsafe Byte GetIndexedPixel(Bitmap b, Int32 x, Int32 y)
    {
        if (b.PixelFormat != PixelFormat.Format8bppIndexed) throw new ArgumentException("Image is not in 8 bit per pixel indexed format!");
        if (x < 0 || x >= b.Width) throw new ArgumentOutOfRangeException("x", string.Format("x should be in 0-{0}", b.Width));
        if (y < 0 || y >= b.Height) throw new ArgumentOutOfRangeException("y", string.Format("y should be in 0-{0}", b.Height));
        BitmapData data = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, b.PixelFormat);
        try
        {
            Byte* scan0 = (Byte*)data.Scan0;
            return scan0[x + y * data.Stride];
        }
        finally
        {
            if (data != null) b.UnlockBits(data);
        }
    }
