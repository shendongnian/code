    public static Byte GetIndexedPixel(Bitmap b, Int32 x, Int32 y)
    {
        if ((b.PixelFormat & PixelFormat.Indexed) == 0) throw new ArgumentException("Image does not have an indexed format!");
        if (x < 0 || x >= b.Width) throw new ArgumentOutOfRangeException("x", string.Format("x should be in 0-{0}", b.Width));
        if (y < 0 || y >= b.Height) throw new ArgumentOutOfRangeException("y", string.Format("y should be in 0-{0}", b.Height));
        BitmapData data = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, b.PixelFormat);
        try
        {
            Byte[] pixel = new Byte[1];
            Marshal.Copy(new IntPtr(data.Scan0.ToInt64() + x + y * data.Stride), pixel, 0, 1);
            return pixel[0];
        }
        finally
        {
            if (data != null) b.UnlockBits(data);
        }
    }
