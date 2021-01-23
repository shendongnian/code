    [DllImport("kernel32.dll", SetLastError=true)] 
    static extern int SetPriorityClass(int hProcess, int dwPriorityClass);
    
    const int PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000;
    
    static void SetBackgroundMode()
    {
       int processId = Process.GetCurrentProcess().Id;
       SetPriorityClass(processId, PROCESS_MODE_BACKGROUND_BEGIN);
    }
