    string Find(string query)
    {
        var retval = null;
        while(!string.IsNullOrEmpty(query) && retval == null)
        {
            if(!_lookupTable.TryGetValue(query, out retval))
                query = query.Substring(0, query.Length-1);
        }
        return retval;
    }
