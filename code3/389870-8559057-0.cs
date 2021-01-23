    private static unsafe byte GetIndexedPixel(Bitmap b, int x, int y)
    {
        if (x < 0 || x >= b.Width) throw new ArgumentOutOfRangeException("x", string.Format("x should be in 0-{0}", b.Width));
        if (x < 0 || x >= b.Height) throw new ArgumentOutOfRangeException("y", string.Format("y should be in 0-{0}", b.Height));
        var data = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, PixelFormat.Indexed);
        try
        {
            var scan0 = (byte*) data.Scan0;
            return scan0[x + y*data.Stride];
        }
        finally
        {
            if (data != null) b.UnlockBits(data);
        }
    }
