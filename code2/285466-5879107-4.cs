    [DllImport("user32.dll")]  
    [return: MarshalAs(UnmanagedType.Bool)]  
    static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);  
    [StructLayout(LayoutKind.Sequential)]  
    public struct RECT  
    {
        public int Left;        // x position of upper-left corner  
        public int Top;         // y position of upper-left corner  
        public int Right;       // x position of lower-right corner  
        public int Bottom;      // y position of lower-right corner  
    }
