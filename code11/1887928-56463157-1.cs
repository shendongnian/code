C#
public static void MyCustomFunc<T>(this T inst, params Expression<Func<T, object>>[] props)
{
    foreach (var p in props)
    {
        PropertyInfo propertyInfo = null;
        
        //  Because the return type of the lambda is object, when the property is a value 
        //  type, the Expression will have to be a unary expression to box the value. 
        //  The MemberExpression will be the operand from that UnaryExpression. 
        if (p.Body is UnaryExpression ue && ue.Operand is MemberExpression ueMember)
        {
            propertyInfo = (PropertyInfo)ueMember.Member;
        }
        else if (p.Body is MemberExpression member)
        {
            propertyInfo = (PropertyInfo)member.Member;
        }
        else
        {
            throw new ArgumentException("Parameters must be property access expressions " 
                + "in the form x => x.Property");
        }
        string name = propertyInfo.Name;
        Type type = propertyInfo.PropertyType;
        Func<T, object> func = p.Compile();
    }
}
Usage:
C#
new MyTestClass { Name = "Stan", StartedAt = DateTime.Now }
    .MyCustomFunc(x => x.Name, x => x.StartedAt);
