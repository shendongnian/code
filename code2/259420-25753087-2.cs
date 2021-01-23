    public class ServicePreshutdownInstaller : ServiceInstaller
    {
        private int _preshutdownTimeout = 200000;
        /// <summary>
        /// Gets or sets the preshutdown timeout for the service.
        /// </summary>
        /// 
        /// <returns>
        /// The preshutdown timeout of the service. The default is 200000ms (200s).
        /// </returns>
        [DefaultValue(200000)]
        [ServiceProcessDescription("ServiceInstallerPreshutdownTimeout")]
        public int PreshutdownTimeout
        {
            get
            {
                return _preshutdownTimeout;
            }
            set
            {
                _preshutdownTimeout = value;
            }
        }
        public override void Install(System.Collections.IDictionary stateSaver)
        {
            base.Install(stateSaver);
            Version versionWinVistaSp1 = new Version(6, 0, 6001);
            if (Environment.OSVersion.Platform != PlatformID.Win32NT || Environment.OSVersion.Version < versionWinVistaSp1)
            {
                //Preshutdown is not supported
                return;
            }
            Context.LogMessage(string.Format("Setting preshutdown timeout {0}ms to service {1}", PreshutdownTimeout, ServiceName));
            IntPtr service = IntPtr.Zero;
            IntPtr sCManager = IntPtr.Zero;
            try
            {
                // Open the service control manager
                sCManager = OpenSCManager(null, null, ServiceControlAccessRights.SC_MANAGER_CONNECT);
                if (sCManager == IntPtr.Zero)
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Unable to open Service Control Manager.");
                // Open the service
                service = OpenService(sCManager, ServiceName, ServiceAccessRights.SERVICE_CHANGE_CONFIG);
                if (service == IntPtr.Zero) throw new Win32Exception();
                // Set up the preshutdown timeout structure
                SERVICE_PRESHUTDOWN_INFO preshutdownInfo = new SERVICE_PRESHUTDOWN_INFO();
                preshutdownInfo.dwPreshutdownTimeout = (uint)_preshutdownTimeout;
                // Make the change
                int changeResult = ChangeServiceConfig2(
                    service,
                    ServiceConfig2InfoLevel.SERVICE_CONFIG_PRESHUTDOWN_INFO,
                    ref preshutdownInfo);
                // Check that the change occurred
                if (changeResult == 0)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Unable to change the Service configuration.");
                }
                Context.LogMessage(string.Format("Preshutdown timeout {0}ms set to service {1}", PreshutdownTimeout, ServiceName));
            }
            finally
            {
                // Clean up
                if (service != IntPtr.Zero)CloseServiceHandle(service);
                if (sCManager != IntPtr.Zero)Marshal.FreeHGlobal(sCManager);
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct SERVICE_PRESHUTDOWN_INFO
        {
            public UInt32 dwPreshutdownTimeout;
        }
        [Flags]
        public enum ServiceControlAccessRights : int
        {
            SC_MANAGER_CONNECT = 0x0001, // Required to connect to the service control manager. 
            SC_MANAGER_CREATE_SERVICE = 0x0002, // Required to call the CreateService function to create a service object and add it to the database. 
            SC_MANAGER_ENUMERATE_SERVICE = 0x0004, // Required to call the EnumServicesStatusEx function to list the services that are in the database. 
            SC_MANAGER_LOCK = 0x0008, // Required to call the LockServiceDatabase function to acquire a lock on the database. 
            SC_MANAGER_QUERY_LOCK_STATUS = 0x0010, // Required to call the QueryServiceLockStatus function to retrieve the lock status information for the database
            SC_MANAGER_MODIFY_BOOT_CONFIG = 0x0020, // Required to call the NotifyBootConfigStatus function. 
            SC_MANAGER_ALL_ACCESS = 0xF003F // Includes STANDARD_RIGHTS_REQUIRED, in addition to all access rights in this table. 
        }
        [Flags]
        public enum ServiceAccessRights : int
        {
            SERVICE_QUERY_CONFIG = 0x0001, // Required to call the QueryServiceConfig and QueryServiceConfig2 functions to query the service configuration. 
            SERVICE_CHANGE_CONFIG = 0x0002, // Required to call the ChangeServiceConfig or ChangeServiceConfig2 function to change the service configuration. Because this grants the caller the right to change the executable file that the system runs, it should be granted only to administrators. 
            SERVICE_QUERY_STATUS = 0x0004, // Required to call the QueryServiceStatusEx function to ask the service control manager about the status of the service. 
            SERVICE_ENUMERATE_DEPENDENTS = 0x0008, // Required to call the EnumDependentServices function to enumerate all the services dependent on the service. 
            SERVICE_START = 0x0010, // Required to call the StartService function to start the service. 
            SERVICE_STOP = 0x0020, // Required to call the ControlService function to stop the service. 
            SERVICE_PAUSE_CONTINUE = 0x0040, // Required to call the ControlService function to pause or continue the service. 
            SERVICE_INTERROGATE = 0x0080, // Required to call the ControlService function to ask the service to report its status immediately. 
            SERVICE_USER_DEFINED_CONTROL = 0x0100, // Required to call the ControlService function to specify a user-defined control code.
            SERVICE_ALL_ACCESS = 0xF01FF // Includes STANDARD_RIGHTS_REQUIRED in addition to all access rights in this table. 
        }
        public enum ServiceConfig2InfoLevel : int
        {
            SERVICE_CONFIG_DESCRIPTION = 0x00000001, // The lpBuffer parameter is a pointer to a SERVICE_DESCRIPTION structure.
            SERVICE_CONFIG_FAILURE_ACTIONS = 0x00000002, // The lpBuffer parameter is a pointer to a SERVICE_FAILURE_ACTIONS structure.
            SERVICE_CONFIG_PRESHUTDOWN_INFO = 0x00000007 // The lpBuffer parameter is a pointer to a SERVICE_PRESHUTDOWN_INFO structure.
        }
        [DllImport("advapi32.dll", EntryPoint = "OpenSCManager")]
        public static extern IntPtr OpenSCManager(
            string machineName,
            string databaseName,
            ServiceControlAccessRights desiredAccess);
        [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
        public static extern int CloseServiceHandle(IntPtr hSCObject);
        [DllImport("advapi32.dll", EntryPoint = "OpenService")]
        public static extern IntPtr OpenService(
            IntPtr hSCManager,
            string serviceName,
            ServiceAccessRights desiredAccess);
        [DllImport("advapi32.dll", EntryPoint = "ChangeServiceConfig2")]
        public static extern int ChangeServiceConfig2(
            IntPtr hService,
            ServiceConfig2InfoLevel dwInfoLevel,
            ref SERVICE_PRESHUTDOWN_INFO lpInfo);
    }
