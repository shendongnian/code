    public static string Filter(string input, params string[] items)
    {
        var filtered = input.Split('|').Where(x => items.Contains(x.Split(':')[0].Trim()));
        return string.Join("|", filtered); 
    }
