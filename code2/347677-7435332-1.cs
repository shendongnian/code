    var input = "BLOCK\r\n    LIST1 Lorem ipsum dolor sit amet ...";
    
    var levels = new List<string> { "BLOCK", "LIST1", "LIST2", "LIST3" };
    var counter = levels.ToDictionary(level => level, level => 0);
    
    // Replace each key word with incremented counter,
    // while resetting deeper levels to 0.
    var result = Regex.Replace(input, string.Join("|", levels), m =>
    {
        for (int i = levels.IndexOf(m.Value) + 1; i < levels.Count; i++)
        {
            counter[levels[i]] = 0;
        }
        return GetLevelToken(m.Value, ++counter[m.Value]);
    });
    
    private static string GetLevelToken(string token, int index)
    {
        switch (token)
        {
            case "BLOCK":
                return index.ToString() + ".";
            case "LIST1":
                return index.ToString() + ".";
            case "LIST2":
                return ((char)('A' + index - 1)).ToString();
        }
        return "";
    }
