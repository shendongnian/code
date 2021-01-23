    private static bool AlreadyRunning()
    {
    	Process[] processes = Process.GetProcesses();
    	Process currentProc = Process.GetCurrentProcess();
    
    	foreach (Process process in processes)
    	{
    		try
    		{
    			if (process.Modules[0].FileName == System.Reflection.Assembly.GetExecutingAssembly().Location
    						&& currentProc.Id != process.Id)
    				return true;
    		}
    		catch (Exception)
    		{
    
    		}
    	}
    
    	return false;
    }
