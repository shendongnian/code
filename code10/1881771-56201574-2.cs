    public int GetMin(string key, List<Dictionary<string, int>> db)
    {
        if (db is null) return 0;
        return  db.SelectMany(d => d).Where(kvp => kvp.Key == key).DefaultIfEmpty().Min(v => v.Value);
    }
