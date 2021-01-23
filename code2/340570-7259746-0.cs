    public static class Win32
    {
        [DllImport("User32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
    }
    public Bitmap CaptureWindow()
    {
        Bitmap bmp = new Bitmap(this.Width,this.Height);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            Win32.PrintWindow(this.Handle, g.GetHdc(), 0);
            g.ReleaseHdc();
        }
        return bmp;
    }
