    public static bool AreExpandosEquals(ExpandoObject obj1, ExpandoObject obj2)
    {
        var obj1AsColl = (ICollection<KeyValuePair<string,object>>)obj1;
        var obj2AsDict = (IDictionary<string,object>)obj2;
        
        // Make sure they have the same number of properties
        if (obj1AsColl.Count != obj2AsDict.Count)
            return false;
        
        foreach (var pair in obj1AsColl)
        {
            // Try to get the same-named property from obj2
            object o;
            if (!obj2AsDict.TryGetValue(pair.Key, out o))
                return false;
            
            // Property names match, what about the values they store?
            if (!object.Equals(o, pair.Value))
                return false;
        }
        
        // Everything matches
        return true;
    }
