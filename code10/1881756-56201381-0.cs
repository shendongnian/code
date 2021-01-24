    public static int? GetMin(string key, List<Dictionary<string, int>> db)
    {
        if (db == null) {
            return null;
        }
        int? result = null;
        foreach (var dic in db) {
            if (dic.TryGetValue(key, out int value) && (result == null || value < result)) {
                result = value;
            }
        }
        return result;
    }
