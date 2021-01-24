    StringBuilder sb = new StringBuilder();
    foreach (DictionaryEntry entry in (IDictionary)dictionary)
    {
        sb.Append($"{entry.Key}={entry.Value};");
    }
    return sb.ToString();
