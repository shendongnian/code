     public static bool ProcessExist(string processname)
            {
                Process[] aProc = Process.GetProcessesByName(processname);
                return (aProc.Length > 0);
            }
