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
        //If not, go on higher in inheritance tree
        baseType = baseType.BaseType;
    }
    //Found nothing
    return derivedTypeMethod.DeclaringType;
}
Problem with Scott's answer is that when you have two methods with different signatures but same name in inheritance tree:
class A
{
    public virtual void Func() { }
    public virtual string Func(string test) { return ""; }
}
class B : A
{
    public override string Func(string test) => base.Func(test);
    public override void Func() => base.Func();
}
class C : B
{
    public override void Func() => base.Func();
}
you will get an `System.Reflection.AmbiguousMatchException: 'Ambiguous match found.'` on
typeof(B).GetMethod("Func",
                BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
