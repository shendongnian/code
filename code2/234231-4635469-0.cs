    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    public static extern bool IsWow64Process(System.IntPtr hProcess, out bool lpSystemInfo);
    public bool IsWow64Process(System.Diagnostics.Process process)
    {
        bool retVal = false;
        IsWow64Process(process.Handle, out retVal);
        return retVal;
    }
