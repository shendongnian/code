    using System.Text.RegularExpressions;
    
    string nonParsed = "8$...";
    
    MatchCollection matches = Regex.Matches(nonparsed, @"(\d+\$)(.*?)#");
    
    StringBuilder result = new StringBuilder();
    
    foreach(Match match in matches)
    {
        result.AppendFormat(", Between {0} and #-> My data is {1}",
            match.Groups[1].Value,
            match.Groups[2].Value);
    }
    
    return result.ToString(2, result.Length - 2));
