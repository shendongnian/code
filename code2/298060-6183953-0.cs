    string[] chars = new string[] { "a", "b", "c" };
    
    List<string> result = new List<string>();
    foreach (int i in Enumerable.Range(0, 4))
    {
    	IEnumerable<string> coll = chars;
    	foreach (int j in Enumerable.Range(0, i))
    	{
    		coll = coll.SelectMany(s => chars, (c, r) => c + r);
    	}
    	result.AddRange(coll);
    }
