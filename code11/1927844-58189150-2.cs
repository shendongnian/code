C#
public static class TypeExtensions
{
    public static bool InheritsFrom(this Type t, Type baseType)
    {
        if (t.BaseType == null)
        {
            return false;
        }
        else if (t == baseType)
        {
            return true;
        }
        else if (t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition().InheritsFrom(baseType))
        {
            return true;
        }
        else if (t.BaseType.InheritsFrom(baseType))
        {
            return true;
        }
        return false;
    }
    public static bool InheritsFrom<TBaseType>(this Type t)
        => t.InheritsFrom(typeof(TBaseType));
}
You'd use it like this:
C#
public static barChecker<T> Generator()
{
    var rtn = new barChecker<T>();
    foreach (var item in typeof(T).GetProperties())
    {
        if (item.PropertyType.InheritsFrom(typeof(foo<>)))
        {
            rtn.fooprops.Add(item);
        }
    }
    return rtn;
}
Or make it generic and parameterize `foo<>`:
C#
public static barChecker<T> Generator2<TInheritsFrom>()
    => new barChecker<T> {
        fooprops = typeof(T).GetProperties()
            .Where(pi => pi.PropertyType.InheritsFrom<TInheritsFrom>())
            .ToList()
    };
And use that like so:
C#
var barchkr = barChecker<SomeClass>.Generate<foo<>>();
