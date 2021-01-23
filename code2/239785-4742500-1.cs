    // the following P/Invoke signatures have been copied from pinvoke.net:
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool MoveWindow(IntPtr hWnd, 
                                           int X, int Y,
                                           int nWidth, int nHeight, 
                                           bool bRepaint);
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;        // x position of upper-left corner
        public int Top;         // y position of upper-left corner
        public int Right;       // x position of lower-right corner
        public int Bottom;      // y position of lower-right corner
    }
    ...
    System.Windows.Form a = ...;
    IntPtr b = ...;
    RECT bRect;
    GetWindowRect(b, out bRect);
    MoveWindow(b,
               a.Location.X + 50, b.Location.Y,
               bRect.Right - bRect.Left, bRect.Bottom - bRect.Top,
               true);
