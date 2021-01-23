    static T GetObject<T>(Dictionary<string, object> dict)
        where T : new()
    {
        var obj = new T();
        foreach (var property in typeof(T).GetProperties())
        {
            var args = new object[1];
            var setter = property.GetSetMethod(); // property has a public setter
            if (setter != null && dict.TryGetValue(property.Name, out args[0]))
                setter.Invoke(obj, args);
        }
        return obj;
    }
