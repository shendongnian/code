    public static string GetComponent(string hwclass, string syntax)
        {
            var mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (var o in mos.Get())
            {
                var mj = (ManagementObject)o;
                CpuModel = Convert.ToString(mj[syntax]);
            }
            return CpuModel;
        }
    private string L2CacheSize = HardwareManagement.GetComponent("Win32_Processor", "L2CacheSize");
    private string L3CacheSize = HardwareManagement.GetComponent("Win32_Processor", "L3CacheSize");
