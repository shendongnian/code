    public void BootTime(){    
        SelectQuery query = new SelectQuery("SELECT LastBootUpTime FROM Win32_OperatingSystem WHERE Primary='true'");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
         
        foreach (ManagementObject mo in searcher.Get())
        {
            DateTime dtBootTime = ManagementDateTimeConverter.ToDateTime(mo.Properties["LastBootUpTime"].Value.ToString());
            Console.WriteLine(dtBootTime.ToString());
        }
    }
