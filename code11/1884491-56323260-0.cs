c#
public static void SwapProperties<T>(T lhs, T rhs, Expression<Func<T, object>> propExpression)
{
    var prop = GetPropertyInfo(propExpression);
    var lhsValue = prop.GetValue(lhs);
    var rhsValue = prop.GetValue(rhs);
    prop.SetValue(lhs, rhsValue);
    prop.SetValue(rhs, lhsValue);
}
private static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> propExpression)
{
    PropertyInfo prop;
    if (propExpression.Body is MemberExpression memberExpression)
    {
        prop = (PropertyInfo) memberExpression.Member;
    }
    else
    {
        var op = ((UnaryExpression) propExpression.Body).Operand;
        prop = (PropertyInfo) ((MemberExpression) op).Member;
    }
    return prop;
}
class Obj
{
    public long Position { get; set; }
    public string Name { get; set; }
}
public static void Main(string[] args)
{
    var a1 = new Obj()
    {
        Position = 10,
        Name = "a1"
    };
    var a2 = new Obj()
    {
        Position = 20,
        Name = "a2"
    };
    SwapProperties(a1, a2, obj => obj.Position);
    SwapProperties(a1, a2, obj => obj.Name);
    Console.WriteLine(a1.Position);
    Console.WriteLine(a2.Position);
    Console.WriteLine(a1.Name);
    Console.WriteLine(a2.Name);
}
