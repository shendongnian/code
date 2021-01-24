    public static int? GetMinLINQ(string key, List<Dictionary<string, int>> db)
    {
        if (db == null) {
            return null;
        }
        return db
            .Select(d => (isMatch: d.TryGetValue(key, out int i), result:i))
            .Where(x => x.isMatch)
            .Select(x=> new Nullable<int>(x.result))
            .Min();
    }
