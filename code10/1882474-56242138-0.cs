    public static IntPtr WinGetHandle(string wName)
    {
        IntPtr hWnd = IntPtr.Zero;
        foreach (Process pList in Process.GetProcesses())
        {
            if (pList.MainWindowTitle.Contains(wName))
            {
                hWnd = pList.MainWindowHandle;
            }
            Console.WriteLine(pList.MainWindowTitle);
        }
        return hWnd;
    }
