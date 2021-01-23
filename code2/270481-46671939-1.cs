    using System.Runtime.InteropServices;
        [DllImport("Kernel32.dll")]
        static extern uint QueryFullProcessImageName(IntPtr hProcess, uint flags, StringBuilder text, out uint size);
        //Get the path to a process
        //proc = the process desired
        private string GetPathToApp (Process proc)
        {
            string pathToExe = string.Empty;
            if (null != proc)
            {
                uint nChars = 256;
                StringBuilder Buff = new StringBuilder((int)nChars);
                uint success = QueryFullProcessImageName(proc.Handle, 0, Buff, out nChars);
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
