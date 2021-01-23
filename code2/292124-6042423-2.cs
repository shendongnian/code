    using System.Text.RegularExpressions;
    
    string nonParsed = "8$...";
    
    MatchCollection matches = Regex.Matches(nonparsed, @"(\d+\$)(.*?)#");
    
    StringBuilder result = new StringBuilder();
    
    for(int i = 0; i < matches.Count; i++)
    {
        Match match = matches[i];
        result.AppendFormat("Between {0} and #-> My data is {1}")
            match.Groups[1].Value,
            match.Groups[2].Value);
       
        if (i < matches.Count - 1)
        {
            result.AppendLine(",");
        }
        else
        {
            result.Append(".");
        }
    }
    
    return result.ToString();
