    private static IEnumerable<KeyValuePair<string, string>>
        Flatten(Dictionary<string, object> dictionary)
    {
        if (dictionary == null) yield break;
        foreach (var entry in dictionary)
        {
            if (entry.Value is string s)
            {
                yield return new KeyValuePair<string, string>(entry.Key, s);
            }
            else if (entry.Value is Dictionary<string, object> innerDictionary)
            {
                foreach (var innerEntry in Flatten(innerDictionary))
                {
                    yield return innerEntry;
                }
            }
            else if (entry.Value == null)
            {
                // Do nothing
            }
            else
            {
                throw new ArgumentException(nameof(dictionary));
            }
        }
    }
