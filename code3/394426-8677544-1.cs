    static T GetObject<T>(Dictionary<string, object> dict)
        where T : new()
    {
        var obj = new T();
        foreach (var property in typeof(T).GetProperties())
        {
            property.SetValue(obj, dict[property.Name], null);
        }
        return obj;
    }
