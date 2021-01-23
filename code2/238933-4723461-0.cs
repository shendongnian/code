    public string[] ExtractURLs(string str)
    {
        // match.Groups["name"].Value - URL Name
        // match.Groups["url"].Value - URI
        string RegexPattern = @"<a.*?href=[""'](?<url>.*?)[""'].*?>(?<name>.*?)</a>"
    
        // Find matches.
        System.Text.RegularExpressions.MatchCollection matches
            = System.Text.RegularExpressions.Regex.Matches(str, RegexPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    
        string[] MatchList = new string[matches.Count];
    
        // Report on each match.
        int c = 0;
        foreach (System.Text.RegularExpressions.Match match in matches)
        {
            MatchList[c] = match.Groups["url"].Value;
            c++;
        }
    
        return MatchList;
    }
