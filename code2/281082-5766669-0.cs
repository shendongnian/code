    public static void Start(string processName, string args, string workingDir = "")
    {
    	var process = new Process
    					  {
    						  StartInfo =
    							  {
    								  FileName = processName,
    								  Arguments = args,
    								  WorkingDirectory = workingDir
    							  }
    					  };
    
    	// Start the process
    	process.Start();
    }
