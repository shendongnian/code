        class Program
        {
         	static async Task Main(string[] args)
         	{
         		try { }
    	     	catch { }
         		// Make sure you use a finally block.
                // If for any reason your code crashes you'd still want this part to run.
    		    finally
        		{
        			if (int.TryPasre(args[X], out parentProcessId))
        				MonitorAgentProcess(parentProcessId);
        		}
        	}
    
        	static void MonitorAgentProcess(int parentProcessId)
        	{
        		try
        		{
        			Process process = Process.GetProcessById(parentProcessId);
        			Task.Run(() => process.WaitForExit())
        				.ContinueWith(t => Environment.Exit(-1));
        		}
        		catch {}
        	}
        }
