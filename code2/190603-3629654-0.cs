    private static bool IsObjectEqualsMethod(MethodInfo m)
    {
        var parameters = m.GetParameters();
        return m.Name == "Equals"
           && parameters.Length == 1
           && parameters.First().ParameterType == typeof(object);
    }
    
    public static bool OverridesEquals(this Type type)
    {
        var equalsMethod = type.GetMethods()
                               .Where(IsObjectEqualsMethod)
                               .Single();
    
        return equalsMethod.DeclaringType != typeof(object);
    }
