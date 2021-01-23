    private void ScanAndDoSmth<TAttribute>(IEnumerable<Assembly> assemblies)
    where TAttribute : Attribute
    {
        var result =
            from assembly in assemblies
            from type in GetAllTypesFromAssemblyByAttribute<TAttribute>(assembly)
            let attributes = type.GetCustomAttributes(typeof(TAttribute), true)
            where attributes != null && attributes.Length > 0
            select new { Type = type, Attributes = attributes.Cast<TAttribute>();
    }
