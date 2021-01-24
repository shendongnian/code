public static bool IsGenericTypeOf(this Type type, Type genericTypeDefinition)
    => type.IsGenericType && type.GetGenericTypeDefinition() == genericTypeDefinition;
public static bool IsImplementationOfGenericType(this Type type, Type genericTypeDefinition)
{
    if (!genericTypeDefinition.IsGenericTypeDefinition)
        return false;
    // looking for generic interface implementations
    if (genericTypeDefinition.IsInterface)
    {
        foreach (Type i in type.GetInterfaces())
        {
            if (i.Name == genericTypeDefinition.Name && i.IsGenericTypeOf(genericTypeDefinition))
                return true;
        }
        return false;
    }
    // looking for generic [base] types
    for (Type t = type; type != null; type = type.BaseType)
    {
        if (t.Name == genericTypeDefinition.Name && t.IsGenericTypeOf(genericTypeDefinition))
            return true;
    }
    return false;
}
Examples:
public class MyList : List<ProductDetails2> { }
//...
typeof(List<ProductDetails2>).IsGenericTypeOf(List<>); // true
typeof(MyList).IsGenericTypeOf(List<>); // false
typeof(MyList).IsImplementationOfGenericType(List<>); // true
typeof(MyList).IsImplementationOfGenericType(IEnumerable<>); // true
