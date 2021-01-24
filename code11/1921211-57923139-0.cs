	public static void Main()
	{
		var input = "abbaaabcbcccd";
		var max = 2;
        // stores count of characters that we added already
		var occurences = new Dictionary<char,int>();
		
		var sb = new StringBuilder();
		foreach (var c in input)
		{
            // add with a count of 0 if not yet encountered
			if (!occurences.ContainsKey(c))
				occurences[c] = 1;
			
            // add character if less then max occurences
			if (occurences[c] <  max)
			{
				sb.Append(c);			
				occurences[c]+=1;
			}
		}
		Console.WriteLine(sb.ToString());  
	}
