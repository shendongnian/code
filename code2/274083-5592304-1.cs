    var somethingTypes = typeof(ISomething)
        .Assembly
        .GetTypes() 
        .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i == typeof(ISomething))
    
    foreach (var t in somethingTypes)
    {
        var o = Activator.CreateInstance(t);
        var mi = (IEnumerable<ISomething>)t.GetMethod("Collection");
        if (mi != null)
        {
            var items = .Invoke(o, null);
            itemRows.UnionWith(items); 
        }
    }
