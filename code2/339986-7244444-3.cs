    using System.Management;
    public string GetHDDSerial()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");    
        ManagementObjectCollection managementObjects = searcher.Get();
        foreach (ManagementObject obj in managementObjects)
        {
            if (obj["SerialNumber"] != null)
                return obj["SerialNumber"].ToString();
        }
    
        return string.Empty;
    }
