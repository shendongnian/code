    void Func<T>()
    {
        T[] values;
        dynamic v = new ExpandoObject();
        var dictionary = (IDictionary<string, object>)v;
        var i = 0;
        foreach (var value in values)
        {
            i++;
            dictionary.Add($"v{i}", value);
        }
    }
