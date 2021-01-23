        string[] listOfFiles = {"file1.txt","file2.txt"};
    	Dictionary<string,string> allLines = new Dictionary<string,string>();
    	
    	foreach (var path in listOfFiles)
    	{
    		foreach (var line in File.ReadAllLines(path))
    		{
    			if (!allLines.ContainsKey(line))
    			{
    				allLines.Add(line,string.Empty);
    			}
    		}
    	}
