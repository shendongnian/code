    [DllImport ("advapi32.dll", SetLastError = true)]
    static extern bool OpenProcessToken (IntPtr ProcessHandle, UInt32 DesiredAccess, out IntPtr TokenHandle);
    [DllImport ("kernel32.dll", SetLastError = true)]
    [return: MarshalAs (UnmanagedType.Bool)]
    static extern bool CloseHandle (IntPtr hObject); 
    static uint TOKEN_QUERY = 0x0008;
    // ...
    public static WindowsIdentity GetUserFromSession(int sessionId)
    {
        return Process.GetProcesses()
            .Where(p => p.SessionId == sessionId)
            .Select(GetUserFromProcess)
            .FirstOrDefault();
    }
    public static WindowsIdentity GetUserFromProcess(Process p)
    {
        IntPtr ph;
        try
        {
            OpenProcessToken (p.Handle, TOKEN_QUERY, out ph);
            return new WindowsIdentity(ph);
        }
        catch (Exception e)
        {
            return null;
        }
        finally
        {
            if (ph != IntPtr.Zero) CloseHandle(ph);
        }
    }
