    internal ITemplate GetTemplate(string template, Type modelType, string name)
    {
        if (!string.IsNullOrEmpty(name))
            if (templateCache.ContainsKey(name))
                return templateCache[name];
        var instance = CreateTemplate(template, modelType);
        if (!string.IsNullOrEmpty(name))
            if (!templateCache.ContainsKey(name))
                templateCache.Add(name, instance);
        return instance;
    }
