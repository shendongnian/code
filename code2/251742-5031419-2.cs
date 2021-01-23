    public static void GetSysInfo(string domain, string machine, string username, string password)
    {
        ManagementObjectSearcher query = null;
        ManagementObjectCollection queryCollection = null;
    
        ConnectionOptions opt = new ConnectionOptions(); 
    
        opt.Impersonation = ImpersonationLevel.Impersonate; 
        opt.EnablePrivileges = true; 
        opt.Username = username; 
        opt.Password = password; 
        try 
        { 
            ManagementPath p = new ManagementPath("\\\\" +machine+ "\\root\\cimv2");   
    
            ManagementScope msc = new ManagementScope(p, opt); 
    
            SelectQuery q= new SelectQuery("Win32_Environment");
    
            query = new ManagementObjectSearcher(msc, q, null); 
            queryCollection = query.Get(); 
    
            Console.WriteLine(queryCollection.Count);
    
            foreach (ManagementBaseObject envVar in queryCollection) 
            {
                Console.WriteLine("System environment variable {0} = {1}", 
                envVar["Name"], envVar["VariableValue"]);
            }
        } 
        catch(ManagementException e) 
        { 
            Console.WriteLine(e.Message); 
            Environment.Exit(1); 
        } 
        catch(System.UnauthorizedAccessException e) 
        { 
            Console.WriteLine(e.Message); 
            Environment.Exit(1); 
        } 
    }
