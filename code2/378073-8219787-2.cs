    var allTypes = AppDomain.Current.GetAssemblies().SelectMany(a => a.GetTypes()).Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(MyClass<>));
    foreach (var type in allTypes) 
    {
      ...
    }
