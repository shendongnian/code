    private string[] getWords(string text)
    {
    	Regex reg = new Regex("/w+");
    	MatchCollection matches = reg.Matches(text);
    	List<string> words = new List<string>();
    	foreach (Match match in matches)
    	{
    		words.Add(match.Value);
    	}
    	return words.ToArray();
    }
