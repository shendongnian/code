    var allLines = File.ReadAllLines(@"c:\test.txt");
    	
    	Dictionary<string, string> allUniques = new Dictionary<string, string>();
    	
    	foreach(string s in allLines)
    	{
    		var chunks = s.Split('|');
    		if (!allUniques.ContainsKey(chunks[0]))
    		{
    			allUniques.Add(chunks[0], s);
    		}		
    	}
    	
    	File.WriteAllLines(@"c:\test2.txt", allUniques.Values.ToArray());
