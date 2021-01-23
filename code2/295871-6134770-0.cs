        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public static void HideWindow()
        {
            int SW_HIDE = 0;
            foreach (Process pr in Process.GetProcesses())
            {
                if (pr.ProcessName.Contains("Procmon"))
                {
                    //Int32 hWnd = pr.MainWindowHandle.ToInt32();
                    ShowWindow(pr.MainWindowHandle, SW_HIDE);
                }
            }
        }
        
        static void Main(string[] args)
        {
            HideWindow();
        }
