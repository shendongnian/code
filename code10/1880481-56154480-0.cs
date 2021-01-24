    public IEnumerable<(string? key, string? value)> GetKeyValue(string line)
    {
        var split = line.Split(':');
        if (split.Length == 2)
            return (split[0].Trim(), split[1].Trim());
        else if (split.Length > 2)
        {
            var joined = string.Join(":", split.ToList().Skip(1));
            yield return (split[0].Trim(), joined.Trim());
        }
        else
        {
            Debug.Print($"Couldn't parse this into key/value: {line}");
        }
    }
