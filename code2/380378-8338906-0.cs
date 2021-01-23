    public int Dpi
    {
        get
        {
            if (this.dpi == 0)
            {
                var desktopHwnd = new HandleRef(null, IntPtr.Zero);
                var desktopDC = new HandleRef(null, SafeNativeMethods.GetDC(desktopHwnd));
                this.dpi = SafeNativeMethods.GetDeviceCaps(desktopDC, 88 /*LOGPIXELSX*/);
                if (SafeNativeMethods.ReleaseDC(desktopHwnd, desktopDC) != 1 /* OK */)
                {
                    // log error
                }
            }
            return this.dpi;
        }
    }
    
    private static class SafeNativeMethods
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(HandleRef hWnd);
        [DllImport("User32.dll")]
        public static extern int ReleaseDC(HandleRef hWnd, HandleRef hDC);
        [DllImport("GDI32.dll")]
        public static extern int GetDeviceCaps(HandleRef hDC, int nIndex);
    }
