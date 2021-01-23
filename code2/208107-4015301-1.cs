    [DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
    public static extern bool SetPriorityClass(IntPtr handle, uint priorityClass);
    
    const uint PROCESS_MODE_BACKGROUND_BEGIN = 0x00100000;
    
    static void SetBackgroundMode()
    {
       int processId = Process.GetCurrentProcess().Id;
       SetPriorityClass(processId, PROCESS_MODE_BACKGROUND_BEGIN);
    }
