    using System.Management;
    public string GetProcessorSerial()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
        ManagementObjectCollection managementObjects = searcher.Get();
    
        foreach (ManagementObject obj in managementObjects)
        {
            if (obj["SerialNumber"] != null)
                return obj["SerialNumber"].Value.ToString();
        }
    
        return String.Empty;
    }
