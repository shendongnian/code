    private string GetFilename(string csvFilename)
    {
    	string path = Path.GetDirectoryName(csvFilename);
    
    	string[] lines = File.ReadAllLines(csvFilename);
    	foreach (string line in lines)
    	{
    	    string[] items = line.Split(',');
    	    string txt = items.First(item => item.ToLower().Trim().EndsWith(".txt"));
    	    if (!String.IsNullOrEmpty(txt)) 
                return Path.Combine(path, txt);
    	}
    	return "";
    }
