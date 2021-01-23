    private Regex captures = new Regex(@"\(.+?\)");
    
    public string ConstructFolderName(string firstGroup, string secondGroup, string pattern)
    {
    	MatchCollection matches = captures.Matches(pattern);
    
    	Regex firstCapture = new Regex(matches[0].Value);
    
    	if (!firstCapture.IsMatch(firstGroup))
    		throw new FormatException("firstGroup");
    
    	Regex secondCapture = new Regex(matches[1].Value);
    
    	if (!secondCapture.IsMatch(secondGroup))
    		throw new FormatException("secondGroup");
    
    	return pattern.Replace(firstCapture.ToString(), firstGroup).Replace(secondCapture.ToString(), secondGroup);
    }
