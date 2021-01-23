    ManagementScope theScope = new ManagementScope("\\\\computerName\\root\\cimv2");
    StringBuilder theQueryBuilder = new StringBuilder();
    theQueryBuilder.Append("SELECT MACAddress FROM Win32_NetworkAdapter");
    ObjectQuery theQuery = new ObjectQuery(theQueryBuilder.ToString());
    ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
    ManagementObjectCollection theCollectionOfResults = theSearcher.Get();
    
    foreach (ManagementObject theCurrentObject in theCollectionOfResults)
    {
        string macAdd = "MAC Address: " + theCurrentObject["MACAddress"].ToString();
        MessageBox.Show(macAdd);
    }
