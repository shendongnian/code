    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_STATUS
    {
        public int serviceType;
        public int currentState;
        public int controlsAccepted;
        public int win32ExitCode;
        public int serviceSpecificExitCode;
        public int checkPoint;
        public int waitHint;
    }
    public enum SERVICE_STATE : uint
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007
    }
    public enum ControlsAccepted
    {
        ACCEPT_STOP = 1,
        ACCEPT_PAUSE_CONTINUE = 2,
        ACCEPT_SHUTDOWN = 4,
        ACCEPT_PRESHUTDOWN = 0xf,
        ACCEPT_POWER_EVENT = 64,
        ACCEPT_SESSION_CHANGE = 128
    }
    [Flags]
    public enum SERVICE_CONTROL : uint
    {
        STOP = 0x00000001,
        PAUSE = 0x00000002,
        CONTINUE = 0x00000003,
        INTERROGATE = 0x00000004,
        SHUTDOWN = 0x00000005,
        PARAMCHANGE = 0x00000006,
        NETBINDADD = 0x00000007,
        NETBINDREMOVE = 0x00000008,
        NETBINDENABLE = 0x00000009,
        NETBINDDISABLE = 0x0000000A,
        DEVICEEVENT = 0x0000000B,
        HARDWAREPROFILECHANGE = 0x0000000C,
        POWEREVENT = 0x0000000D,
        SESSIONCHANGE = 0x0000000E
    }
    public enum INFO_LEVEL : uint
    {
        SERVICE_CONFIG_DESCRIPTION = 0x00000001,
        SERVICE_CONFIG_FAILURE_ACTIONS = 0x00000002,
        SERVICE_CONFIG_DELAYED_AUTO_START_INFO = 0x00000003,
        SERVICE_CONFIG_FAILURE_ACTIONS_FLAG = 0x00000004,
        SERVICE_CONFIG_SERVICE_SID_INFO = 0x00000005,
        SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO = 0x00000006,
        SERVICE_CONFIG_PRESHUTDOWN_INFO = 0x00000007,
        SERVICE_CONFIG_TRIGGER_INFO = 0x00000008,
        SERVICE_CONFIG_PREFERRED_NODE = 0x00000009
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SERVICE_PRESHUTDOWN_INFO
    {
        public UInt32 dwPreshutdownTimeout;
    }
    [Flags]
    public enum SERVICE_ACCESS : uint
    {
        STANDARD_RIGHTS_REQUIRED = 0xF0000,
        SERVICE_QUERY_CONFIG = 0x00001,
        SERVICE_CHANGE_CONFIG = 0x00002,
        SERVICE_QUERY_STATUS = 0x00004,
        SERVICE_ENUMERATE_DEPENDENTS = 0x00008,
        SERVICE_START = 0x00010,
        SERVICE_STOP = 0x00020,
        SERVICE_PAUSE_CONTINUE = 0x00040,
        SERVICE_INTERROGATE = 0x00080,
        SERVICE_USER_DEFINED_CONTROL = 0x00100,
        SERVICE_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED |
          SERVICE_QUERY_CONFIG |
          SERVICE_CHANGE_CONFIG |
          SERVICE_QUERY_STATUS |
          SERVICE_ENUMERATE_DEPENDENTS |
          SERVICE_START |
          SERVICE_STOP |
          SERVICE_PAUSE_CONTINUE |
          SERVICE_INTERROGATE |
          SERVICE_USER_DEFINED_CONTROL)
    }
    [Flags]
    public enum SCM_ACCESS : uint
    {
        STANDARD_RIGHTS_REQUIRED = 0xF0000,
        SC_MANAGER_CONNECT = 0x00001,
        SC_MANAGER_CREATE_SERVICE = 0x00002,
        SC_MANAGER_ENUMERATE_SERVICE = 0x00004,
        SC_MANAGER_LOCK = 0x00008,
        SC_MANAGER_QUERY_LOCK_STATUS = 0x00010,
        SC_MANAGER_MODIFY_BOOT_CONFIG = 0x00020,
        SC_MANAGER_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED |
          SC_MANAGER_CONNECT |
          SC_MANAGER_CREATE_SERVICE |
          SC_MANAGER_ENUMERATE_SERVICE |
          SC_MANAGER_LOCK |
          SC_MANAGER_QUERY_LOCK_STATUS |
          SC_MANAGER_MODIFY_BOOT_CONFIG
    }
    public partial class Service1 : ServiceBase
    {        
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        internal static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);
        [DllImport("advapi32.dll")]
        internal static extern bool SetServiceStatus(IntPtr hServiceStatus, ref SERVICE_STATUS lpServiceStatus);
        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ChangeServiceConfig2(IntPtr hService, int dwInfoLevel, IntPtr lpInfo);
        [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);
        const int SERVICE_ACCEPT_PRESHUTDOWN = 0x100;
        const int SERVICE_CONTROL_PRESHUTDOWN = 0xf;
        public Service1()
        {
            InitializeComponent();
            CanShutdown = true;
            tim = new Timer();
            tim.Interval = 5000;
            tim.Elapsed += tim_Elapsed;
            FieldInfo acceptedCommandsFieldInfo = typeof(ServiceBase).GetField("acceptedCommands", BindingFlags.Instance | BindingFlags.NonPublic);
            int value = (int)acceptedCommandsFieldInfo.GetValue(this);
            acceptedCommandsFieldInfo.SetValue(this, value | SERVICE_ACCEPT_PRESHUTDOWN);
            StreamWriter writer = new StreamWriter("D:\\LogConst.txt", true);
            try
            {
                IntPtr hMngr = OpenSCManager("localhost", null, (uint)SCM_ACCESS.SC_MANAGER_ALL_ACCESS);
                IntPtr hSvc = OpenService(hMngr, "WindowsService1", (uint)SCM_ACCESS.SC_MANAGER_ALL_ACCESS);
                SERVICE_PRESHUTDOWN_INFO spi = new SERVICE_PRESHUTDOWN_INFO();
                spi.dwPreshutdownTimeout = 5000;
                IntPtr lpInfo = Marshal.AllocHGlobal(Marshal.SizeOf(spi));
                if (lpInfo == IntPtr.Zero)
                {
                    writer.WriteLine(String.Format("Unable to allocate memory for service action, error was: 0x{0:X} -- {1}", Marshal.GetLastWin32Error(), DateTime.Now.ToLongTimeString()));
                }
                Marshal.StructureToPtr(spi, lpInfo, false);
                // apply the new timeout value
                if (!ChangeServiceConfig2(hSvc, (int)INFO_LEVEL.SERVICE_CONFIG_PRESHUTDOWN_INFO, lpInfo))
                    writer.WriteLine(DateTime.Now.ToLongTimeString() + " Failed to change service timeout");
                else
                    writer.WriteLine(DateTime.Now.ToLongTimeString() + " change service timeout : " + spi.dwPreshutdownTimeout);
            }
            catch (Exception ex)
            {
                writer.WriteLine(DateTime.Now.ToLongTimeString() + " " + ex.Message);
            }
            writer.Close();
        }
        void tim_Elapsed(object sender, ElapsedEventArgs e)
        {
            result = false;
            StreamWriter writer = new StreamWriter("D:\\hede.txt", true);
            writer.WriteLine(DateTime.Now.ToLongTimeString());
            //System.Threading.Thread.Sleep(5000);
            writer.Close();
            result = true;
            tim.Stop();
        }
        Timer tim;
        bool result = false;
        protected override void OnStart(string[] args)
        {
            RequestAdditionalTime(1000);
            tim.Start();
        }
        protected override void OnStop()
        {
        }
        protected override void OnCustomCommand(int command)
        {
            StreamWriter writer = new StreamWriter("D:\\Log.txt", true);
            try
            {
                if (command == SERVICE_CONTROL_PRESHUTDOWN)
                {
                    int checkpoint = 1;
                    writer.WriteLine(DateTime.Now.ToLongTimeString());
                    while (!result)
                    {
                        SERVICE_STATUS myServiceStatus = new SERVICE_STATUS();
                        myServiceStatus.currentState = (int)SERVICE_STATE.SERVICE_STOP_PENDING;
                        myServiceStatus.serviceType = 16;
                        myServiceStatus.serviceSpecificExitCode = 0;
                        myServiceStatus.checkPoint = checkpoint;
                        SetServiceStatus(this.ServiceHandle, ref myServiceStatus);
                        checkpoint++;
                    }
                    writer.WriteLine(DateTime.Now.ToLongTimeString());
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine(DateTime.Now.ToLongTimeString() + " " + ex.Message);
            }
            writer.Close();
            base.OnCustomCommand(command);
        }
    }
}
