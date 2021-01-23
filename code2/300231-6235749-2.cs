    var input = new List<string>()
	{
	    "user_1 has joined the game",
		"user_2 has joined the game",
		"user_1 has left the game",
		"user_3 has joined the game"
	};
	
	var joined = new List<string>();
	var left = new List<string>();
	
	foreach(string s in input)
	{   
	    var idx = s.IndexOf(" has joined the game");
	    if (idx > -1)
		{
		    joined.Add(s.Substring(0, idx)); 
			continue;
		}
		
		idx = s.IndexOf(" has left the game");
	    if (idx > -1)
		{
		    left.Add(s.Substring(0, idx)); 
		}
	}
		
	var current = joined.Where(x => !left.Contains(x)).ToList();
	foreach(string user in current)
	{
		Console.WriteLine(user + " is still in the game"); 
    }
