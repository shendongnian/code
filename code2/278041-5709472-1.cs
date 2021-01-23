    public static System.Drawing.Bitmap BitmapSourceToBitmap2(BitmapSource srs)
    {
        int width = srs.PixelWidth;
        int height = srs.PixelHeight;
        int stride = width * ((srs.Format.BitsPerPixel + 7) / 8);
        IntPtr ptr = IntPtr.Zero;
        try
        {
            ptr = Marshal.AllocHGlobal(height * stride);
            srs.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
            using (var btm = new System.Drawing.Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, ptr))
            {
                // Clone the bitmap so that we can dispose it and
                // release the unmanaged memory at ptr
                return new System.Drawing.Bitmap(btm);
            }
        }
        finally
        {
            if (ptr != IntPtr.Zero)
                Marshal.FreeHGlobal(ptr);
        }
    }
