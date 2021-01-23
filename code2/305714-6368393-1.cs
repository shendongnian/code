    using System.Management;
    public bool IsServerVersion()
    {
        var productType = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem")
                .Get().OfType<ManagementObject>()
                .Select(o => o.GetPropertyValue("ProductType")).First();
    
        // ProductType will be one of:
        // 1: Workstation
        // 2: Domain Controller
        // 3: Server
    
        return productType != 1;
    }
