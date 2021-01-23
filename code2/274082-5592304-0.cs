    var somethingTypes = typeof(ISomething)
        .Assembly
        .GetTypes() 
        .Where(t => t.GetInterfaces().Any(i => i == typeof(ISomething))
    
    foreach (var t in somethingTypes)
    {
        var o = Activator.CreateInstance(t);
        var items = (IEnumerable<ISomething>)t.GetMethod("Collection").Invoke(o, null);
        itemRows.UnionWith(items);
    }
