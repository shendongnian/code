        ManagementScope mgtScope = new ManagementScope("\\\\ComputerName\\root\\cimv2");
        // you could also replace the username in the select with * to query all objects
        ObjectQuery objQuery = new ObjectQuery("SELECT username FROM Win32_ComputerSystem");
        ManagementObjectSearcher srcSearcher = new ManagementObjectSearcher(mgtScope, objQuery);
        ManagementObjectCollection colCollection = srcSearcher.Get();
        foreach (ManagementObject curObjCurObject in colCollection)
        {
            Console.WriteLine(curObjCurObject["username"].ToString());
        } 
      //if you want ot get the name of the machine that changed it once it gets into that  Event change the query to look like this. I just tested this locally and it does work 
        ManagementObjectSearcher mosQuery = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ProcessId = " + Process.GetCurrentProcess().Id.ToString());
        ManagementObjectCollection queryCollection1 = mosQuery.Get();
        foreach (ManagementObject manObject in queryCollection1)
        {
            Console.WriteLine("Name : " + manObject["name"].ToString());
            Console.WriteLine("Version : " + manObject["version"].ToString());
            Console.WriteLine("Manufacturer : " + manObject["Manufacturer"].ToString());
            Console.WriteLine("Computer Name : " + manObject["csname"].ToString());
            Console.WriteLine("Windows Directory : " + manObject["WindowsDirectory"].ToString());
        }  
 
