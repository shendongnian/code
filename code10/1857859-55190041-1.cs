    public static bool IsSameAsProperty(PropertyInfo first, PropertyInfo second)
    {
        if (first.DeclaringType == second.DeclaringType && first.Name == second.Name)
            return true;
        bool firstIsSecond = second.DeclaringType.IsAssignableFrom(first.DeclaringType);
        bool secondIsFirst = first.DeclaringType.IsAssignableFrom(second.DeclaringType);
        if (firstIsSecond || secondIsFirst)
        {
            PropertyInfo baseProp = firstIsSecond ? second : first;
            PropertyInfo derivedProp = firstIsSecond ? first : second;
            MethodInfo baseMethod, implMethod;
            if (baseProp.GetMethod != null && derivedProp.GetMethod != null)
            {
                baseMethod = baseProp.GetMethod;
                implMethod = derivedProp.GetMethod;
            }
            else if (baseProp.SetMethod != null && derivedProp.SetMethod != null)
            {
                baseMethod = baseProp.SetMethod;
                implMethod = derivedProp.SetMethod;
            }
            else
            {
                return false;
            }
            // Is it somehow possible to create a situation where both get and set exist
            // and the set method to be an implementation while the get method is not?
            if (baseMethod.DeclaringType.IsInterface)
                return IsInterfaceImplementation(implMethod, baseMethod);
            else
                return IsOverride(implMethod, baseMethod);
        }
        return false;
    }
    private static bool IsInterfaceImplementation(MethodInfo implMethod, MethodInfo interfaceMethod)
    {
        InterfaceMapping interfaceMap = implMethod.DeclaringType.GetInterfaceMap(interfaceMethod.DeclaringType);
        int index = Array.IndexOf(interfaceMap.InterfaceMethods, interfaceMethod);
        // I don't think this can ever be the case?
        if (index == -1)
            return false;
        MethodInfo targetMethod = interfaceMap.TargetMethods[index];
        return implMethod == targetMethod || IsOverride(implMethod, targetMethod);
    }
    private static bool IsOverride(MethodInfo implMethod, MethodInfo baseMethod)
    {
        return implMethod.GetBaseDefinition() == baseMethod.GetBaseDefinition();
    }
