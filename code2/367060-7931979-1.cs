    string BuildDictionaryString(IEnumerable collection)
    {
        var sb = new StringBuilder();
        foreach (var o in collection) sb.Append(o.ToString());
        return sb.ToString();
    }
    row["configurations"] = car.Configurations.BuildDictionaryString();
    row["optionals"] = car.Optionals.BuildDictionaryString();
