    public int GetMin(string key, List<Dictionary<string, int>> db)
    {
        if (db == null || db.Count == 0) return 0;
        return  db.SelectMany(d => d).Where(kvp => kvp.Key == key).DefaultIfEmpty().Min(v => v.Value);
    }
