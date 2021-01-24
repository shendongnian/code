    Dictionary<string, int> commands = new Dictionary<string, int>()
    		{{"start", 1}, {"stop", 2}, {"end", 2}};
    string input = Console.ReadLine();
    if (commands.ContainsKey((input.ToLower())))	// this checks if the input is equal to any of the keys present in the Dictionary
    {
    	if (input.ToLower() == "end" || input.ToLower() == "stop")
    	{
    				// do this
                    // you can also get the value from Dictionary by key here
    	}
    }
