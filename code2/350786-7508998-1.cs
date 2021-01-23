    IEnumerable<Process> GetProcessesWhereNameContains(string text)
    {
    	// Could be web-service or database call too
    	var processes = System.Diagnostics.Process.GetProcesses();
    	foreach (var process in processes)
    	{
    		if (process.ProcessName.Contains(text))
    		{
    			yield return process;
    		}
    	}
    }
