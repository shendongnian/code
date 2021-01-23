    public static string GetPropertyName<T>(Expression<Func<T, object>> e)
    {
        var stack = new Stack<string>();
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
        while (me != null)
        {
            stack.Push(me.Member.Name);
            me = me.Expression as MemberExpression;
        }
        return string.Join(".", stack.ToArray());
    }
