    public static System.Drawing.Bitmap BitmapSourceToBitmap2(BitmapSource srs)
    {
        System.Drawing.Bitmap btm = null;
        int width = srs.PixelWidth;
        int height = srs.PixelHeight;
        int stride = width * ((srs.Format.BitsPerPixel + 7) / 8);
        IntPtr ptr = Marshal.AllocHGlobal(height * stride);
        srs.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
        btm = new System.Drawing.Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, ptr);
        return btm;
    }
