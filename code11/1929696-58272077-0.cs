    protected string GetDistinctName2(string currentName, IEnumerable<string> existingNames)
    {
        int iteration = 0;
    	var name = currentName;
    	while(existingNames.Contains(name))
    	{	
    		name = currentName + "_[" + (iteration++) + "]";
    	}
    
        return name;
    }
