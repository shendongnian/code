    public string SplitAsWords(string original)
    {
        var matches = Regex.Matches(original, "[A-Z][a-z]*").Cast<Match>();
        var str = string.Join(" ", matches.Select(match => match.Value));
        str = str[0] + str.Substring(1).ToLower();
        return str;
    }
