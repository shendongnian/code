    void Main()
    {
    	string test = "<html>wowzers description: none <div>description:a1fj391</div></html>";
        IEnumerable<string> results = getDescriptions(test);
    	foreach (string result in results)
    	{
    		Console.WriteLine(result);	
    	}
    	
    	//result: none
        //        a1fj391
    }
    
    static Regex MyRegex = new Regex(
    	  "description:\\s*(?<value>[\\d\\w]+)",
    	RegexOptions.Compiled);
    	
    IEnumerable<string> getDescriptions(string html)
    {
    	foreach(Match match in MyRegex.Matches(html))
    	{
    		yield return match.Groups["value"].Value;
    	}
    }
