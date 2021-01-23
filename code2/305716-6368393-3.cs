    public bool IsServerVersion()
    {
        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
        {
            foreach (ManagementObject managementObject in searcher.Get())
            {
                // ProductType will be one of:
                // 1: Workstation
                // 2: Domain Controller
                // 3: Server
                uint productType = (uint)managementObject.GetPropertyValue("ProductType");
                return productType != 1;
            }
        }
    
        return false;
    }
