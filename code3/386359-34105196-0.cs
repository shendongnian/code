    private static Graphics graphics = null;
    private static IntPtr hdc = IntPtr.Zero;
    private static IntPtr dstHdc = IntPtr.Zero;
    
    private static Capture()
    {
        if (graphics == null)
        {
           hdc = GetDC(IntPtr.Zero);
           graphics = Graphics.FromImage(bitmap);
           dstHdc = graphics.GetHdc();
        }
        BitBlt(dstHdc, 0, 0, screen_resolution.Width, screen_resolution.Height, hdc, 0, 0, RasterOperation.SRC_COPY);
    }
