    private void AddEntry(ObjectType type, string key, string value)
    {
        Dictionary<string, string> tmp;
        // Assume "dictionary" is the field
        if (!dictionary.TryGetValue(type, out tmp))
        {
            tmp = new Dictionary<string, string>();
            dictionary[type] = tmp;
        }
        tmp.Add(key, value);
    }
