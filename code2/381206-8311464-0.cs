    static void Main(string[] args)
    {
    	GetProcesses();
    	GetApplications();
    	Console.Read();
    }
    public static void GetProcesses()
    {
    	StringBuilder sb = new StringBuilder();
    	ManagementClass MgmtClass = new ManagementClass("Win32_Process");
    
    	foreach (ManagementObject mo in MgmtClass.GetInstances())           
    		Console.WriteLine("Name:" + mo["Name"] + "ID:" + mo["ProcessId"]);               
    
    	Console.WriteLine();
    }
    
    public static void GetApplications()
    {
    	StringBuilder sb = new StringBuilder();
    	foreach (Process p in Process.GetProcesses("."))
    		try
    		{
    			if (p.MainWindowTitle.Length > 0)
    			{
    				Console.WriteLine("Window Title:" + p.MainWindowTitle.ToString());
    				Console.WriteLine("Process Name:" + p.ProcessName.ToString());
    				Console.WriteLine("Window Handle:" + p.MainWindowHandle.ToString());
    				Console.WriteLine("Memory Allocation:" + p.PrivateMemorySize64.ToString());                     
    			}
    		}
    		catch { }
    }
