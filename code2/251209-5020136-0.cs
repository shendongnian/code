    IDictionary<string, object> GetDictionaryFromObject(object obj)
    {
        if(obj == null) return new Dictionary<string, object>();
        return obj.GetType().GetProperties().
                    ToDictionary(p => p.Name,
                                 p => p.GetValue(obj, null) ?? DBNull.Value)
    }
