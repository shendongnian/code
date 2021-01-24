public static Type GetMethodDeclaringTypeClosestInHierarchy(MethodInfo derivedTypeMethod)
{
    //Method is not virtual, you have the only definition in inheritance tree
    if (!derivedTypeMethod.IsVirtual) return derivedTypeMethod.DeclaringType;
    var baseType = derivedTypeMethod.DeclaringType.BaseType;
    while (baseType != null)
    {
        //Check if in base type there is a method
        if (baseType.GetMethods().Any(baseTypeMethod =>
            //that has same base definition like then one we're checking
            baseTypeMethod.GetBaseDefinition() == derivedTypeMethod.GetBaseDefinition()
            //and is actually overriden in baseType
            && baseTypeMethod.DeclaringType == baseType))
        {
            return baseType;
        }
        //If not, go on higher in object inheritance tree
        baseType = baseType.BaseType;
    }
    //Found nothing
    return derivedTypeMethod.DeclaringType;
}
