    ConnectionOptions opts = new ConnectionOptions();
    ManagementScope scope = new ManagementScope(@"\\.\root\cimv2", opts);
    string query = "select * from Win32_Keyboard";
    System.Management.ObjectQuery oQuery = new ObjectQuery(query);
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, oQuery);
    ManagementObjectCollection recordSet = searcher.Get();
    foreach (ManagementObject record in recordSet)
    {
        Console.WriteLine("" + record.Properties["Description"].Value);
        Console.WriteLine("" + record.Properties["Layout"].Value);
        Console.WriteLine("" + record.Properties["DeviceID"].Value);
        Console.WriteLine("" + record.Properties["PNPDeviceID"].Value);
        Console.WriteLine("" + record.Properties["Status"].Value + "\n");
    }
