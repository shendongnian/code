    private static T DictionaryToObject<T>(IDictionary<string, object> dict) where T : new()
    {
        T t = new T();
        PropertyInfo[] properties = t.GetType().GetProperties();
        foreach (PropertyInfo property in properties)
        {
            if (!dict.Any(x => x.Key.Equals(property.Name, 
                StringComparison.InvariantCultureIgnoreCase)))
                continue;
            KeyValuePair<string, object> item = dict.First(x => x.Key.Equals(property.Name,
                StringComparison.InvariantCultureIgnoreCase));
            Type tPropertyType = t.GetType().GetProperty(property.Name).PropertyType;
            Type newT = Nullable.GetUnderlyingType(tPropertyType) ?? tPropertyType;
            object newA = Convert.ChangeType(item.Value, newT);
            t.GetType().GetProperty(property.Name).SetValue(t, newA, null);
        }
        return t;
    }
