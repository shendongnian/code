    var result = new Dictionary<string, List<string>>();
    
    // Loop through each key/value pair in the dictionary
    foreach (var kvp in dict)
    {
        // kvp.Key is the key ("a", "b", etc)
        // kvp.Value is the list of values ("Red", "Yellow", etc)
        // Loop through each of the values
        foreach (var value in kvp.Value)
        {
            // See if our results dictionary already has an entry for this
            // value. If so, grab the corresponding list of keys. If not,
            // create a new list of keys and insert it.
            if (!result.TryGetValue(value, out var list))
            {
                list = new List<string>();
                result.Add(value, list);
            }
            // Add our key to this list of keys
            list.Add(kvp.Key);
        }
    }
