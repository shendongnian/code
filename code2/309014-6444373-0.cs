    public string Parse<T>(string template, T model, string name = null)
    {
        var instance = GetTemplate(template, typeof(T), name);
        ...
    }
