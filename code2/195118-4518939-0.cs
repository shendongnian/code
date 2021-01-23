       [RunInstaller(true)]
        public partial class MyInstaller: Installer
        {
            String installerPath;
    
            public MyInstaller()
            {
                InitializeComponent();       
                if (Is64Bit())//running as 64-bit
                {
                    installerPath= @"installfolder\my64bitsetup.exe";
                }
                else
                {
                    installerPath= @"installfolder\my32bitsetup.exe";
                }
            }
    
            [SecurityPermission(SecurityAction.Demand)]
            public override void Install(IDictionary stateSaver)
            {
                base.Install(stateSaver);
            }
    
            [SecurityPermission(SecurityAction.Demand)]
            public override void Commit(IDictionary savedState)
            {
                base.Commit(savedState);
                MyInstall();
            }
    
            [SecurityPermission(SecurityAction.Demand)]
            public override void Rollback(IDictionary savedState)
            {
                base.Rollback(savedState);
            }
    
            [SecurityPermission(SecurityAction.Demand)]
            public override void Uninstall(IDictionary savedState)
            {
                base.Uninstall(savedState);
                base.Commit(savedState);
            }
    
            private void MyInstall()
            {
                 ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe", "/c " + installerPath);
                RunProcess(procStartInfo);
            }
    
            private void RunProcess(ProcessStartInfo procStartInfo)
            {
                Process proc = new Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                proc.WaitForExit();
            }
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);
        private bool Is64Bit()
        {
            if (IntPtr.Size == 8 || (IntPtr.Size == 4 && Is32BitProcessOn64BitProcessor()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Is32BitProcessOn64BitProcessor()
        {
            bool retVal;
            IsWow64Process(Process.GetCurrentProcess().Handle, out retVal);
            return retVal;
        }
