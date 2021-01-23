    var allAbrList = new List<List<string>>
                     {
                     	new List<string> {"BOULEVARD", "BOUL", "BOULV", "BLVD"},
                     	new List<string> {"STREET", "ST", "STR"},
                     	// ...
                     };
    
    var allAbrLookup = new Dictionary<string, List<string>>();
    foreach (List<string> list in allAbrList)
    {
    	foreach (string abbr in list)
    	{
    		allAbrLookup.Add(abbr, list);
    	}
    }
