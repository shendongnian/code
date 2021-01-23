        string strProcessorId = string.Empty;
        SelectQuery query = new SelectQuery("Win32_processor");
        ManagementObjectSearcher search = new ManagementObjectSearcher(query);
        foreach (ManagementObject info in search.Get())
        {
            strProcessorId = info["ProcessorID"].ToString();
        }
        Console.WriteLine(strProcessorId);
        Console.ReadLine();
