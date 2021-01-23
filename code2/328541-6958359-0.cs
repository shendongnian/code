    private readonly Regex _regex = new Regex("([<])([^>]*)([>])", RegexOptions.Compiled);
    private string sunshine()
    {
        string input = "I'm walking on <sunshine>.";
        var match = _regex.Match(input);
        string result = "";
        for (int i = 0; i < match.Groups.Count; i++)
        {
            result += string.Format("Group {0}: {1}\n", i, match.Groups[i].Value);
        }
        result += "\nWhat you're getting: " + match.Groups[2].Value + match.Groups[3].Value;
        result += "\nWhat you want: " + match.Groups[0].Value + " or " + match.Value;
        
        var regex2 = new Regex("<[^>]*>", RegexOptions.Compiled);
        result += "\nBut you don't need all those brackets and groups: " + regex2.Match(input).Value;
        return result;
    }
