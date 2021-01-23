    using System.Runtime.InteropServices;
    [DllImport("psapi.dll")]
    static extern uint GetProcessImageFileName(IntPtr hProcess, StringBuilder text, uint size);
    //Get the path to a process
    //proc = the process desired
    private string GetPathToApp (Process proc)
    {
        string pathToExe = string.Empty;
        if (null != proc)
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            uint success = GetProcessImageFileName(proc.Handle, Buff, nChars);
            if (0 != success)
            {
                pathToExe = Buff.ToString();
            }
            else
            {
                int error = Marshal.GetLastWin32Error();
                pathToExe = ("Error = " + error + " when calling GetProcessImageFileName");
            }
        }
        return pathToExe;
    }
