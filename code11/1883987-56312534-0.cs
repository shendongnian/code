        static UInt32 GetProccessByName(string targetProcessName)
        {
            UInt32[] processes = new UInt32[1024];
            UInt32 bytesCopied;
            if (!Psapi.EnumProcesses(processes, (UInt32)processes.Length, out bytesCopied))
            {
                return 0;
            }
            foreach (var pid in processes)
            {
                IntPtr handle = Kernel32.OpenProcess(
                  (Kernel32.ProcessAccessFlags.QueryInformation |
                    Kernel32.ProcessAccessFlags.VirtualMemoryRead),
                    false,
                    (int)pid);
                UInt32[] modules = new UInt32[1024];
                UInt32 bytesNeeeded;
                if (handle != null)
                {
                    if (Psapi.EnumProcessModules(handle, modules, (UInt32)modules.Length, out bytesNeeeded))
                    {
                        StringBuilder text = new StringBuilder(1024);
                        Psapi.GetModuleBaseName(handle, IntPtr.Zero, text, (UInt32)text.Capacity);
                        if (text.Equals(targetProcessName))
                        {
                            return pid;
                        }
                    }
                }
            }
            return 0;
        }
        public static bool EnumProc(IntPtr hWnd, ref SearchData data)
        {
            UInt32 pid;
            User32.GetWindowThreadProcessId(hWnd, out pid);
            if(pid == data.PID)
            {
                data.Windows.Add(hWnd);
            }
            return true;
        }
        static List<IntPtr> GetWindowFromProcessID(UInt32 pid)
        {
            var searchData = new SearchData(pid);
            User32.EnumWindows(new User32.EnumWindowsProc(EnumProc), ref searchData);
            return searchData.Windows;
        }
        static void Main(string[] args)
        {
            var pid = GetProccessByName("HxOutlook.exe");
            var windows = GetWindowFromProcessID(pid);
            foreach (var window in windows)
            {
                var owner = User32.GetWindow(window, User32.GetWindowType.GW_OWNER);
                if(owner != null)
                {
                    User32.ShowWindow(owner, SW_RESTORE);
                }
            }
        }
