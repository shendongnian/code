    private Dictionary<string, Data> SearchQuery(Dictionary<string, Data> _Dictionary, string _KeyWord)
    {
        return _Dictionary
            // Use string.Contains on both keys and values
            .Where(p => p.Value.Class.Contains(_KeyWord) || p.Key.Contains(_KeyWord))
            // GroupBy for a dictionary is redundant afaik since every key is unique
            // First order by keys then by the values
            .OrderBy(x => x.Key).ThenBy(x => x.Value.Class)
            // return all Values not only linking all keys to only the first value ...
            .ToDictionary(p => p.Key, p => p.Value);
    }
