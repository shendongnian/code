    public List<string> ReadTextFile(string filePath)
    {
    	var ret = new List<string>();
    	
    	if (!File.Exists(filePath))
    		throw new FileNotFoundException();
    	
    	// Using the "using" directive removes the need of calling StreamReader.Close
    	// when we're done with the object - it closes itself.
    	using (var sr = new StreamReader(filePath, Encoding.UTF8))
    	{
    		var line;
    	
    		while ((line = sr.ReadLine()) != null)
    			ret.Add(line);
    	}
    	
    	return ret;
    }
