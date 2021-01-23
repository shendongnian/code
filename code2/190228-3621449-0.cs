    Dictionary<string, List<string>> FindAnagrams(List<string> dictionary)
    {
        return dictionary
            .GroupBy(w => new string(((IEnumerable<char>)w).OrderBy(c => c).ToArray()))
            .Where(g => g.Count() > 1)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
