        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, 
            int x, int y, int width, int height, uint uFlags);
        private const uint SHOWWINDOW = 0x0040;
        private void resizeItunes()
        {
            System.Diagnostics.Process[] itunesProcesses = 
                System.Diagnostics.Process.GetProcessesByName("iTunes");
            if (itunesProcesses.Length > 0)
            {
                SetWindowPos(itunesProcesses[0].MainWindowHandle, this.Handle,
                    0, 0, Screen.GetWorkingArea(this).Width * 2 / 3,
                    Screen.GetWorkingArea(this).Height, SHOWWINDOW);
            }
        }
