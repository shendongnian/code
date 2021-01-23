    public void parseFromString(string input, out int id, out string name, out int count)
    {
        var r = new Regex(@"(\d+),(\w+),(\d+)", RegexOptions.IgnoreCase);
        var match = r.Match(input);
        if(match.Success)
        {
            id = int.Parse(match.Groups[1].Value);
            name = match.Groups[2].Value;
            count = int.Parse(match.Groups[3].Value);     
        }
    }
