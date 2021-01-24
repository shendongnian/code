    public IEnumerable<string> SplitStr(string input)
    {
        foreach (Match m in Regex.Matches(input, @"([^=\s,]+=)(""[^""]+""|[^,\s]+)"))
        {
            yield return string.Concat(m.Groups[1].Value, m.Groups[2].Value.Trim('"'));
        }
    }
