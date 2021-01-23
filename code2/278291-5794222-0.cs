    public static Image DrawToBitmap(IntPtr handle)
    {
        RECT rect = new RECT();
        GetWindowRect(handle, ref rect);
    
        Bitmap image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top);
    
        using (Graphics graphics = Graphics.FromImage(image))
        {
            IntPtr hDC = graphics.GetHdc();
            PrintWindow(new HandleRef(graphics, handle), hDC, 0);
            graphics.ReleaseHdc(hDC);
        }
    
        return image;
    }
    
    #region Interop
            
    [DllImport("USER32.DLL")]
    private static extern bool PrintWindow(HandleRef hwnd, IntPtr hdcBlt, int nFlags);
    
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);
    
    [StructLayout(LayoutKind.Sequential)]
    private struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    
    #endregion
