    private static bool IsObjectEqualsMethod(MethodInfo m)
    {
        return m.Name == "Equals"
            && m.GetBaseDefinition().DeclaringType.Equals(typeof(object));
    }
    
    public static bool OverridesEqualsMethod(this Type type)
    {
        var equalsMethod = type.GetMethods()
                               .Single(IsObjectEqualsMethod);
                                 
        return !equalsMethod.DeclaringType.Equals(typeof(object));
    }
