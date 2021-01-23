    var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(MyClass<>));
    foreach (var type in allTypes) 
    {
      ...
    }
