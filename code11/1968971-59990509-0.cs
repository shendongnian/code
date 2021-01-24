    private Dictionary<string , Data> SearchQuery ( Dictionary<string , Data> _Dictionary, string _KeyWord)
    {
        return _Dictionary
            // Use string.Contains on both keys and values
            .Where(p => p.Value.Class.Contains(_KeyWord) || p.Key.Contains(_KeyWord))
            .GroupBy(k => k.Key)
            .OrderBy(x => x.Key)
            // return all Values not only linking all keys to only the first value ...
            .ToDictionary(p => p.Key, p => p.Value);
    }
