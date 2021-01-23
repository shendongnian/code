    /// <summary>
    /// Wait for a child window of an application to appear
    /// </summary>
    /// <param name="appName">Application name to check (will check all instances)</param>
    /// <param name="childWindowName">Name of child window to look for (titlebar)</param>
    /// <param name="timeout">Maximum time, in milliseconds, to wait</param>
    /// <returns>True if the window was found; false if it wasn't.</returns>
    public static bool WaitForChildWindow(string appName, string childWindowName, int timeout)
    {
        int sleepTime = timeout;
        while (sleepTime > 0)
        {
            Process[] processes = Process.GetProcessesByName(appName);
            foreach (Process p in processes)
            {
                IntPtr pMainWindow = p.MainWindowHandle;
                IntPtr pFoundWindow = FindWindowEx(pMainWindow, IntPtr.Zero, null, childWindowName);
                if (pFoundWindow != IntPtr.Zero)
                    return true;
            }
            Thread.Sleep(100);
            sleepTime -= 100;
        }
        // Timed out!
        return false;
    }
