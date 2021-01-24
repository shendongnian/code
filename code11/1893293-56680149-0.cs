    public static string SerializeObject(this IEnumerable<KeyValuePair<string, StringValues>> model)
    {
        if (!model.Any())
            return string.Empty;
        var dic = new Dictionary<string, string>();
        foreach (var kv in model)
            dic.Add(kv.Key, kv.Value);
        return JsonConvert.SerializeObject(dic);
    }
