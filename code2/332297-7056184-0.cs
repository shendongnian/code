    void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
    	List<string> currentlyRunningProcesses = System.Diagnostics.Process.GetProcesses().ToList().ConvertAll(p => p.ProcessName);
    	if (lastRunningProcesses.Count > 0)
    	{
    		List<string> closedProcesses = lastRunningProcesses.FindAll(p => !currentlyRunningProcesses.Contains(p));
    		if (closedProcesses.Count > 0)
    			MessageBox.Show(string.Format("{0} process(es) have been closed:\n{1}", closedProcesses.Count, string.Join("\n", closedProcesses)));
    	}
    	lastRunningProcesses = currentlyRunningProcesses;
    }
