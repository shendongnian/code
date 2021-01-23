    using (Bitmap bitmap = new Bitmap(width, height)) {
        using (Graphics gb = Graphics.FromImage(bitmap))
        using (Graphics gc = Graphics.FromHwnd(_control.Handle)) {
              IntPtr hdcDest = IntPtr.Zero;
              IntPtr hdcSrc = IntPtr.Zero;
              try {
                  hdcDest = gb.GetHdc();
                  hdcSrc = gc.GetHdc();
                  BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, SRC_COPY);
              } finally {
                  if (hdcDest != IntPtr.Zero) gb.ReleaseHdc(hdcDest);
                  if (hdcSrc != IntPtr.Zero) gc.ReleaseHdc(hdcSrc);
              }
          }
          bitmap.Save(...);
    }
    [DllImport("gdi32.dll", EntryPoint = "BitBlt")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool BitBlt(
        [In()] System.IntPtr hdc, int x, int y, int cx, int cy,
        [In()] System.IntPtr hdcSrc, int x1, int y1, uint rop);
    private const int SRC_COPY = 0xCC0020;
