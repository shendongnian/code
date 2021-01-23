    public String MatchExtra(string head, string extra)
    {
    	string result = "";
    
    	if (!head.Contains(extra))
    		return head;
    
    	string criteria = extra + "\\([a-zA-Z0-9\\.\\+\\-\\*\\/]+\\)";
    	MatchCollection match1 = Regex.Matches(head, criteria, RegexOptions.IgnoreCase);
    	foreach (Match bracket_match in match1)
    	{
    		if (bracket_match.Success)
    		{   // not finish if bracket have bracket
    			for (int y = 0; y < bracket_match.Captures.Count; y++)
    			{
    				string a = bracket_match.Captures[y].ToString();
    				string b = bracket_match.Captures[y].ToString().Substring(extra.Length + 1, bracket_match.Captures[y].ToString().Length - extra.Length - 2);
    				result = MatchExtra(bracket_match.Captures[y].ToString().Substring(extra.Length + 1, bracket_match.Captures[y].ToString().Length - extra.Length - 2), extra);
    				return result;
    			}
    		}
    	}
    
    	string criteria2 = extra + "\\(.*\\)";
    	MatchCollection match2 = Regex.Matches(head,  criteria, RegexOptions.IgnoreCase);
    	foreach (Match bracket_match in match2)
    	{
    		if (bracket_match.Success)
    		{   // not finish if bracket have bracket
    			for (int y = 0; y < bracket_match.Captures.Count; y++)
    			{
    				string a = bracket_match.Captures[y].ToString();
    				string b = bracket_match.Captures[y].ToString().Substring(extra.Length+1, bracket_match.Captures[y].ToString().Length - extra.Length -2);
    				result = MatchExtra(bracket_match.Captures[y].ToString().Substring(extra.Length+1, bracket_match.Captures[y].ToString().Length - extra.Length-2), extra);
    				return result;
    			}
    		}
    	}
    	return result;
    }
