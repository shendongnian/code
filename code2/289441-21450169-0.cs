    [DllImport("gdi32.dll")]
    static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
    public enum DeviceCap
    {
        VERTRES = 10,
        DESKTOPVERTRES = 117,
        // http://pinvoke.net/default.aspx/gdi32/GetDeviceCaps.html
    }  
    private float getScalingFactor()
    {
        Graphics g = Graphics.FromHwnd(IntPtr.Zero);
        IntPtr desktop = g.GetHdc();
        int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
        int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES); 
        float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;
        return ScreenScalingFactor; // 1.25 = 125%
    }
