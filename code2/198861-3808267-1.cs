    using System.Management;
    private static string GetProcessorID()
        {
          ManagementClass mgt = new ManagementClass("Win32_Processor");
          ManagementObjectCollection procs= mgt.GetInstances();
            foreach ( ManagementObject item in procs)
                 return item.Properties["Name"].Value.ToString();
            return "Unknown";
        }
