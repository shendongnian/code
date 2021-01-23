    private Boolean isProcessWindowed(Process externalProcess)
    {
        if (externalProcess.MainWindowHandle != IntPtr.Zero)
        {
            return true;
        }
    
        foreach (ProcessThread threadInfo in externalProcess.Threads)
        {
            IntPtr[] windows = GetWindowHandlesForThread(threadInfo.Id);
    
            if (windows != null)
            {
                foreach (IntPtr handle in windows)
                {
                    if (IsWindowVisible(handle))
                    {
                        return true;
                    }
                }
            }
        }
    
        return false;
    }
    
    private IntPtr[] GetWindowHandlesForThread(int threadHandle)
    {
        results.Clear();
        EnumWindows(WindowEnum, threadHandle);
        
        return results.ToArray();
    }
    
    private delegate int EnumWindowsProc(IntPtr hwnd, int lParam);
    
    private List<IntPtr> results = new List<IntPtr>();
    
    private int WindowEnum(IntPtr hWnd, int lParam)
    {
        int processID = 0;
        int threadID = GetWindowThreadProcessId(hWnd, out processID);
        if (threadID == lParam)
        {
            results.Add(hWnd);
        }
    
        return 1;
    }
    
    [DllImport("user32.Dll")]
    private static extern int EnumWindows(EnumWindowsProc x, int y);
    [DllImport("user32.dll")]
    public static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
    [DllImport("user32.dll")]
    static extern bool IsWindowVisible(IntPtr hWnd);
