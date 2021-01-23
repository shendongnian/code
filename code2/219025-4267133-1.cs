    public static string GetPropertyName<T>(Expression<Func<T, object>> e)
    {
        MemberExpression me;
        switch (e.Body.NodeType)
        {
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
                var ue = e.Body as UnaryExpression;
                me = ((ue != null) ? ue.Operand : null) as MemberExpression;
                break;
            default:
                me = e.Body as MemberExpression;
                break;
        }
        if (me == null)
            throw new ArgumentException("Expression must represent field or property access.", "e");
        var stack = new Stack<string>();
        do
        {
            stack.Push(me.Member.Name);
            me = me.Expression as MemberExpression;
        } while (me != null);
        return string.Join(".", stack);    // use "stack.ToArray()" on .NET 3.5
    }
