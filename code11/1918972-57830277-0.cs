    public void ReplaceValues(string s, IEnumerable<string> newValues) 
    {
        if (deps.TryGetValue(s, out var hs)) {
            hs.Clear();
            foreach (var value in newValues)
            { hs.Add(value); }
        }
    }
