    ... (optional caches) ...
    IDictionary<Type, IEnumerable<Attributes>> typeAttributeCache = new ...
    IDictionary<MethodInfo, IEnumerable<Attributes>> methodAttributeCache = new ...
    
    ... (in another method or class) ...
    foreach assembly in GetAssemblies()
      foreach type in assembly.GetTypes()        
        typeAttributes = typeAttributeCache.TryGet(...) // you know the correct syntax, trying to be brief
        
        if (typeAttributes is null)
          typeAttributes = type.GetCustomAttributes().OfType<TypeImLookingFor>();
          typeAttributeCache[type] = typeAttributes;
        
        foreach methodInfo in type.GetMethods()        
          methodAttributes = methodAttributeCache.TryGet(...) // same as above
        
          if (methodAttributes is null)
            methodAttributes = methodInfo.GetCustomAttributes().OfType<TypeImLookingFor>();
            methodAttributeCache[type] = methodAttributes;
        
        // do what you need to do
