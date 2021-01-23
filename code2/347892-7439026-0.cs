    Regex r = new Regex("<Text>(.*)</Text>");
    var matches = r.Matches(f);
    var sb = new StringBuilder();
    foreach (Match match in matches)
    {
        sb.Append(match.Groups[1]);
                
    }
    var g = sb.ToString();
