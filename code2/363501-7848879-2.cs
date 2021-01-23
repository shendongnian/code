	Process[] runningProcesses = Process.GetProcesses();
	var currentSessionID = Process.GetCurrentProcess().SessionId;
	Process[] sameAsThisSession =
        runningProcesses.Where(p => p.SessionId == currentSessionID).ToArray();
	foreach (var p in sameAsthisSession)
	{
	   Trace.WriteLine(p.ProcessName); 
	}
