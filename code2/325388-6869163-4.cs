    bool WaitForPrintWindow(string appName)
    {
        int sleepTime = 5000;
        while (sleepTime > 0)
        {
            Process[] processes = Process.GetProcessesByName(appName);
            foreach (Process p in processes)
            {
                 IntPtr pFoundWindow = p.MainWindowHandle;
                 IntPtr printDialog = FindWindowEx(pFoundWindow, null, null, "Print");
                 if (printDialog != null)
                    return true;
             }
             Thread.Sleep(100);
             sleepTime -= 100;
         }
         // Timed out!
         return false;
    }
