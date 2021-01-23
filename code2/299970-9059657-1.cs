    private void FocusSkype()
        {
            Process[] objProcesses = System.Diagnostics.Process.GetProcessesByName("skype");
            if (objProcesses.Length > 0)
            {
                IntPtr hWnd = IntPtr.Zero;
                hWnd = objProcesses[0].MainWindowHandle;
                ShowWindowAsync(new HandleRef(null,hWnd), SW_RESTORE);
                 SetForegroundWindow(objProcesses[0].MainWindowHandle);
            }
        }
