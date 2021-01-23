    private sting IncrementValues(string input, int increment)
    {
        //assuming your input is: POTATO = -3000;
        //                        POTATO = 1020;    !this value is updated 2011-08-28";
    
    	string pattern = @"(?<=POTATO = )(-?\d+)(?=;)";
    	
    	var regex = new System.Text.RegularExpressions.Regex(pattern, 
    	System.Text.RegularExpressions.RegexOptions.Multiline);
    	
    	return regex.Replace(input, delegate(Match match)
    	{
    		long value = Convert.ToInt64(match.Groups[1].Value);
    
    		return (value + 5000).ToString();
    	});
    }
