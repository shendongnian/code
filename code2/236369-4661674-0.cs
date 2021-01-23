    public IEnumerable<string> GetMatchingKeys(int value)
    {
        var valueText = value.ToString();
        return _dictionary.Keys.Where(key => key.Contains(valueText));
    }
