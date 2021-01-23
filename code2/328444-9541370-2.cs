    SelectQuery query = new SelectQuery("Win32_PrintJob");
    
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
    using (ManagementObjectCollection printJobs = searcher.Get())
        foreach (ManagementObject printJob in printJobs)
        {
            // The format of the Win32_PrintJob.Name property is "PrinterName,JobNumber"
            string name = (string) printJob["Name"];
            string[] nameParts = name.Split(',');
            string printerName = nameParts[0];
            string jobNumber = nameParts[1];
            string document = (string) printJob["Document"];
            string jobStatus = (string) printJob["JobStatus"];
            
            // Process job properties...
        }
