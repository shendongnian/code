    ManagementScope mscope = new ManagementScope(@"\root\CIMV2", options);
    mscope.Connect();
    System.Management.ObjectQuery oQuery = new ObjectQuery("Select * from Win32_TCPIPPrinterPort");
    System.Management.ManagementObjectSearcher searcher = new ManagementObjectSearcher(mscope, oQuery);
    ManagementObjectCollection moCollection = searcher.Get();
    
    foreach (ManagementObject mo in moCollection)
    {
        string name = mo["Name"].ToString();
    
        if (name.Equals(this.portName))
        {
            System.Threading.Thread.Sleep(10000);
            mo["HostAddress"] = this.printerIP;
            mo.Put();
            Console.WriteLine("Adjusted Printer Port to new IP address " + this.printerIP);
            return true;
        }
    }
