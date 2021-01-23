    var types = new Dictionary<Type, Type>
    {
        {typeof(IFoo), typeof(FooThing)},
        {typeof(IBar), typeof(BarThing)},
        ...
    }
    
    foreach(var entry in types)
    {
        if(entry.Key.IsAssignableFrom(node.GetType()))
           return Activator.CreateInstance(entry.Value);
    }
    return null;
