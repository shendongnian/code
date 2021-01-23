    void LogFile(string lockedFilePath)
    {
    	Assembly ass = Assembly.GetExecutingAssembly();
    	string workingFolder = System.IO.Path.GetDirectoryName(ass.Location);
    	string LogFile = System.IO.Path.Combine(workingFolder, "logFiles.txt");
    
    	using (System.IO.StreamWriter sw = new StreamWriter(LogFile, true))
    	{
    		sw.WriteLine(lockedFilePath);   
    	}
    }
