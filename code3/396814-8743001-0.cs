    static IEnumerable<string> ReadLines(string filename)
    {
    	using (TextReader reader = File.OpenText(filename))
    	{
    		string line;
    		while ((line = reader.ReadLine()) != null)
    		{
    			yield return line;
    		}
    	}
    }
    
    // And use the function somewhere to parse the log
    
    var logEntries = new List<LogEntry>()
    foreach (string line in ReadLines("log.txt"))
    {
    	logEntries.Add(ParseLogEntry(line));
    }
