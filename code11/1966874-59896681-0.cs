    public static object FromDictToAnonymousObj<TValue>(IDictionary<string, TValue> dict)
    {
        var types = new Type[dict.Count];
    
        for (int i = 0; i < types.Length; i++)
        {
            types[i] = typeof(TValue);
        }
    
        // dictionaries don't have an order, so we force an order based
        // on the Key
        var ordered = dict.OrderBy(x => x.Key).ToArray();
    
        string[] names = Array.ConvertAll(ordered, x => x.Key);
    
        Type type = AnonymousType.CreateType(types, names);
    
        object[] values = Array.ConvertAll(ordered, x => (object)x.Value);
    
        object obj = type.GetConstructor(types).Invoke(values);
    
        return obj;
    }
