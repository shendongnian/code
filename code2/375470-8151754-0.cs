    var value;
    if (!dictionary.TryGetValue(key, out value))
    {
        lock(dictionary)
        {
            if(!dictionary.TryGetValue(key, out value))
            {
                value = CreateSerializer(...);
                dictionary[key] = value;
            }
        }
    }
    
    
