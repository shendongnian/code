    public string GetStructuredName(Expression<Func<object>> nameObject)
    {
        if (nameObject == null) throw new ArgumentNullException("nameObject");
        // find the expression denoting a property or a field
        MemberExpression member = null;
        switch (nameObject.Body.NodeType)
        {
            case ExpressionType.MemberAccess:
                member = (MemberExpression)nameObject.Body;
                break;
            case ExpressionType.Convert:
            case ExpressionType.ConvertChecked:
                member = ((UnaryExpression)nameObject.Body).Operand as MemberExpression;
                break;
        }
        if (member == null) throw new ArgumentNullException("nameObject");
        StringBuilder sb = new StringBuilder();
        // use the value of the member as the final component of the resulting name
        sb.Append(nameObject.Compile().DynamicInvoke());
        // use short names of embedded type names as components of the resulting name
        Type type = member.Member.DeclaringType;
        while (type != null && type != typeof(Object))
        {
            sb.Insert(0, ".");
            sb.Insert(0, type.Name);
            type = type.DeclaringType;
        }
        return sb.ToString();
    }
