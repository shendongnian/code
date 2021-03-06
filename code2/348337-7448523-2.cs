    string SplitCapital(string str)
    {
    	var capLetters = str
    		.Select((c, i) => new { c = c, i = i })
    		.Where(c => c.i != 0 && Char.IsUpper(c.c));
    
    	if (!capLetters.Any() || capLetters.Count() == str.Length)
    	{
    		return str;
    	}
    
    	var sb = new StringBuilder(str);
    	foreach (var capLetter in capLetters.Reverse())
    	{
    		sb.Insert(capLetter.i, ' ');
    	}
    
    	return sb.ToString();
    }
    
    string SplitCapital(string str, out string[] parts)
    {
    	var splitted = SplitCapital(str);
    	parts = splitted.Split(new[] { ' ' }, StringSplitOptions.None);
    	return splitted;
    }
