    public bool RemovePrinter(string printerName)
    {
            ManagementScope scope = new ManagementScope(ManagementPath.DefaultPath);
            scope.Connect();
            SelectQuery query = new SelectQuery("select * from Win32_Printer");
            ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection printers = search.Get();
            foreach (ManagementObject printer in printers)
            {
                string printerName = printer["Name"].ToString().ToLower();
    
                if (printerName.Equals(printerName.ToLower()))
                {
                    printer.Delete();
                    break;
                }
            }                    
    
            return true;
    }
    
