    static string FormatString(string format, string[] args)
    {
        System.Text.RegularExpressions.Regex RegExp;
        System.Text.RegularExpressions.MatchCollection matches;
        string result;
    
        result = format;
    
        RegExp = new System.Text.RegularExpressions.Regex(@"\{(\d{1,2})\}", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        matches = RegExp.Matches(result);
    
        foreach (System.Text.RegularExpressions.Match match in matches)
        {
            int index;
    
            index = Convert.ToInt32(match.Value.Substring(1, match.Value.Length - 1));
            result = result.Replace(match.Value, args[index]);
        }
    
        matches = null;
        RegExp = null;
    
        return result;
    }
