    var cache = new Dictionary<Assembly,Attribute[]>();
    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
        var attributes = new List<SerializableAttribute>();
        foreach (Type type in assembly.GetTypes())
        {
            attributes.AddRange(
                                type.GetCustomAttributes(false)
                                .OfType<SerializableAttribute>()
                                .ToList());
        }
        cache[assembly] = attributes.ToArray();
    }
