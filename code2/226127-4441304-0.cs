    Process visualStudioProcess = null;
    //Process[] allProcesses = Process.GetProcessesByName("VCSExpress"); // Only do this if you know the exact process name
    // Grab all of the currently running processes
    Process[] allProcesses = Process.GetProcesses();
    foreach (Process process in allProcesses)
    {
    	// My process is called "VCSExpress" because I have C# Express, but for as long as I've known, it's been called "devenv". Change this as required
    	if (process.ProcessName.ToLower() == "vcsexpress" ||
    		process.ProcessName.ToLower() == "devenv"
    		/* Other possibilities*/)
    	{
    		// We have found the process we were looking for
    		visualStudioProcess = process;
    		break;
    	}
    }
    
    // This is done outside of the loop because I'm assuming you may want to do other things with the process
    if (visualStudioProcess != null)
    {
    	SetWindowText(visualStudioProcess.MainWindowHandle, "Hello World");
    }
