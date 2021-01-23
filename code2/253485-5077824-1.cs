        // Sets the window to be foreground 
        [DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);
        // Activate or minimize a window 
        [DllImportAttribute("User32.DLL")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOW = 5;
        private const int SW_MINIMIZE = 6; private const int SW_RESTORE = 9;
        private void ActivateApplication(string strAppName)
        {
            Process[] pList = Process.GetProcessesByName(strAppName);
            if (pList.Length > 0)
            {
                ShowWindow(pList[0].MainWindowHandle, SW_RESTORE);
                SetForegroundWindow(pList[0].MainWindowHandle);
            }
        }
