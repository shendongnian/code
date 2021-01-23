    Type containingType = typeof (CacheManager);
    var method = containingType.GetMethod("CodeLookup", 
        BindingFlags.Static | BindingFlags.Public, null, new Type[0], new ParameterModifier[0]);
    var concreteMethod = method.MakeGenericMethod(targetType);
    Dictionary<string,int> codes = (Dictionary<string,int>)concreteMethod.Invoke(null, null);
