    static IEnumerable<MethodInfo> GetExplicitlyImplementedMethods(this Type targetType, 
        Type interfaceType) 
    { 
      return targetType.GetInterfaceMap(interfaceType).TargetMethods.Where(m => m.IsPrivate);
    }
