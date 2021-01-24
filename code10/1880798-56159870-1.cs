    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);
    private void OpenOutlookAndKillProcess()
    {
       int pid = -1;
       //Get PID
       outlookApp = new Outlook.Application();
       HandleRef hwnd = new HandleRef(outlookApp, (IntPtr)outlookApp.Hwnd);
       GetWindowThreadProcessId(hwnd, out pid);
       .....
       //Finally
       KillProcess(pid,"OUTLOOK");
    }
    
    private void KillProcess(int pid, string processName)
    {
        System.Diagnostics.Process[] AllProcesses = System.Diagnostics.Process.GetProcessesByName(processName);
        foreach (System.Diagnostics.Process process in AllProcesses)
        {
           if (process.Id == pid) process.Kill();
        }
        AllProcesses = null;
    }
