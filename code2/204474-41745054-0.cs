    void Main()
    {
    	var d1 = new Dictionary<string, string>
    	{
    		["a"] = "Hi there!",
    		["b"] = "asd",
    		["c"] = "def"
    	};
    	var d2 = new Dictionary<string, string>
    	{
    		["b"] = "asd",
    		["a"] = "Hi there!",
    		["c"] = "def"
    	};
    
    	var sortedDictionary1 = new SortedDictionary<string, string>(d1);
        var sortedDictionary2 = new SortedDictionary<string, string>(d2);
    
    	if (sortedDictionary1.SequenceEqual(sortedDictionary2))
    	{
    		Console.WriteLine("Match!");
    	}
    	else
    	{
    		Console.WriteLine("Not match!");
    	}
    }
