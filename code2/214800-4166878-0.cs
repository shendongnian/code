    private Regex captures = new Regex(@"(\(.+?\))");
    
    public string ConstructFolderName(string firstGroup, string secondGroup, string pattern)
    {
    	MatchCollection matches = captures.Matches(pattern);
    
    	return pattern.Replace(matches[0].Value, firstGroup).Replace(matches[1].Value, secondGroup);
    }
