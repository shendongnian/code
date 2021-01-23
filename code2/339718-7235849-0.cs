    void Main()
    {
    	string input = "    _  _     _  _  _  _  _ \r\n  | _| _||_||_ |_   ||_||_|\r\n  ||_  _|  | _||_|  ||_| _|";
    	
    	string[] result = SplitIntoNumbers(input);
    }
    
    public string[] SplitIntoNumbers(string input)
    {
    	List<string> results = new List<string>();
    
    	Regex rx = new Regex("(.{3})");
    	MatchCollection matches = rx.Matches(input);
    	int totalNumbers = matches.Count / 3;
    	
    	for(int i = 0; i < totalNumbers; i++)
    	{
    		string s = string.Concat(matches[i].Value, matches[i + totalNumbers].Value, matches[i + (totalNumbers * 2)].Value);
    		
    		results.Add(s);
    	}
    	
    	return results.ToArray();
    }
