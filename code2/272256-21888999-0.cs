    string cmd = string.Format(" /C ATTRIB -R  \"{0}\\*.*\" /S /D", binPath);
    CallCommandlineApp("cmd.exe", cmd);
    
    private static bool CallCommandlineApp(string progPath, string arguments)
    {
       var info = new ProcessStartInfo()
    	{
    		UseShellExecute = false,
    		RedirectStandardOutput = true,
    		FileName = progPath,
    		Arguments = arguments
    
    	};
    
    	var proc = new Process()
    	{
    		StartInfo = info
    	};
    	proc.Start();
    
    	using (StreamReader stReader = proc.StandardOutput)
    	{
    		string output = stReader.ReadToEnd();
    		Console.WriteLine(output);
    
    	}
    
    	// TODO: Do something with standard error. 
    	proc.WaitForExit();
    	return (proc.ExitCode == 0) ? true : false;
    }
