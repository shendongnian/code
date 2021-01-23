    public static class WinApi
    {
    
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    
        public static class Windows
        {
            public const int NORMAL = 1;
            public const int HIDE = 0;
            public const int RESTORE = 9;
            public const int SHOW = 5;
            public const int MAXIMIXED = 3;
        }
    
    }
