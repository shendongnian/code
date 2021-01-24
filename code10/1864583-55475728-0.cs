    public static string Replace(string input, Dictionary<string, object> replacement)
    {
        var regex = new Regex("{(?<placeholder>[a-z_][a-z0-9_]*?)}",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return regex.Replace(input, m =>
        {
            var key = m.Groups["placeholder"].Value;
            if (replacement.TryGetValue(key, out var value))
                return value.ToString();
            throw new Exception($"Unknown key {key}");
        });
    }
    
