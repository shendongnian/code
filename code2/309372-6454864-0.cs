    var results = new Dictionary<char, List<int>>();
    
    foreach (var line in File.ReadAllLines(@"input.txt"))
    {
    	var split = line.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
    	var num = int.Parse(split[0].TrimEnd(':'));
    	
    	for (int i = 1; i < split.Length; i++)
    	{
    		char letter = split[i][0];
    		if (!results.ContainsKey(letter))
    			results[letter] = new List<int>();
    		
    		results[letter].Add(num);
    	}
    }
