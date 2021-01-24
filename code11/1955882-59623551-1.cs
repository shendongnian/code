    string commandText = $"/C p4 -u {UserName} -c {Client.Name} where {string.Join(" ", filePaths)}";
    
    var process = new Process()
    {
    	StartInfo = new ProcessStartInfo()
    	{
    		UseShellExecute = false,
    		CreateNoWindow = true,
    		WindowStyle = ProcessWindowStyle.Hidden,
    		FileName = "cmd.exe",
    		Arguments = commandText,
    		RedirectStandardError = true,
    		RedirectStandardOutput = true
    
    	}
    };
    
    process.Start();
    
    string processTextResult = process.StandardOutput.ReadToEnd();
    
    var exitCode = process.ExitCode;
    var errorMsg = process.StandardError.ReadToEnd();
    
    
    process.Dispose();
    if (exitCode == 0)
    {
    	var resultLines = processTextResult.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    
    	List<FileSpec> fileSpecResults = new List<FileSpec>();
    
    	foreach (var resultLine in resultLines)
    	{
    		var splitedLine = resultLine.Split(' ');
    
    		if (!splitedLine.First().StartsWith("-"))
    		{
    			fileSpecResults.Add(new FileSpec(new DepotPath(splitedLine[0]), new ClientPath(splitedLine[1]), new LocalPath(splitedLine[2]), null));
    		}
    	}
    
    	return fileSpecResults;
    }
    else
    {
    	Logger.TraceError("P4 error - get file spec :" + errorMsg);
    	return new List<FileSpec>();
    }
