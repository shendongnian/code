    void HideConsole()
    {
        MyConsole.HideConsole();
    }
    internal class MyConsole
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32")]
        static extern bool AllocConsole();
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        public static void HideConsole()
        {
            var handle = GetConsoleWindow();
            // Hide
            ShowWindow(handle, SW_HIDE);
        }
        public static void ShowConsole()
        {
            AllocConsole();
        }
    }
