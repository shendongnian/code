    public IEnumerable<string> GetStrings(string originalText,string wordToReplace)
    {
    	Regex rx = new Regex($" {wordToReplace} ",RegexOptions.Compiled | RegexOptions.IgnoreCase);
        MatchCollection matches = rx.Matches(originalText);
    	matches.Dump();
    	foreach(Match match in matches)
    	{
    		var strBuilder = new StringBuilder(originalText);
    		strBuilder.Remove(match.Index,match.Length);
    		strBuilder.Insert(match.Index," ### ");
    		yield return strBuilder.ToString();
    	}
    }
