    public static Dictionary<Type, IEnumerable<Type>> GetInterfaceHierarchyMap(this Type type)
    {
        List<Type> typeAncestry = new List<Type>();
        Type ancestor = type;
        while(ancestor != null)
        {
            typeAncestry.Add(ancestor);
            ancestor = ancestor.BaseType;
        }
        Dictionary<Type, IEnumerable<Type>> interfaceMaps = new Dictionary<Type, IEnumerable<Type>>();
        foreach(Type childType in typeAncestry.Reverse<Type>())
        {
            var mappedInterfaces = interfaceMaps.SelectMany(kvp => kvp.Value);
            var allInterfacesToPoint = childType.GetInterfaces();
            interfaceMaps.Add(childType, allInterfacesToPoint.Except(mappedInterfaces));
        }
        return interfaceMaps;
    }
    
