    static IEnumerable<string> CreateMatchesLog(string patternFilePath, string pathToSearch)
    {
    	string logTemplate = "File {0}, Line: {1}, Pattern: {2}";
    	DirectoryInfo di = new DirectoryInfo(pathToSearch);
    	var patternlines = File.ReadAllLines(patternFilePath);
    	var fileslines = di.EnumerateFiles().Select(fi => File.ReadAllLines(fi.FullName).Select((line, i) => new {fi.FullName, line, i}));
    
    	return from filelines in fileslines
    		   from pattern in patternlines
    		   from fileline in filelines
    		   where fileline.line.Contains(pattern)
    		   select String.Format(logTemplate, fileline.FullName, fileline.i + 1, pattern);
    }
    
