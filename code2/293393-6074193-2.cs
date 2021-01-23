    public static T GetDefaultValue<T>(
        Expression<Func<T, MyClass>> propertySelector)
    {
        MemberExpression memberExpression = null;
        switch (expression.Body.NodeType)
        {
            case ExpressionType.MemberAccess:
                // This is the default case where the 
                // expression is simply member access.
                memberExpression 
                    = expression.Body as MemberExpression;
                break;
            case ExpressionType.Convert:
                // This case deals with conversions that 
                // may have occured due to typing.
                UnaryExpression unaryExpression 
                    = expression.Body as UnaryExpression;
                if (unaryExpression != null)
                {
                    memberExpression 
                        = unaryExpression.Operand as MemberExpression;
                }
                break;
        }
        MemberInfo member = memberExpression.Member;
        // Check for field and property types. 
        // All other types are not supported by attribute model.
        switch (member.MemberType)
        {
            case MemberTypes.Property:
                break;
            default:
                throw new Exception("Member is not property");
        }
        var property = (PropertyInfo)member;
    
        var attribute = property
            .GetCustomAttribute(typeof(DefaultValueAttribute)) 
                as DefaultValueAttribute;
    
        if(attribute != null)
        {
            return (T)attribute.Value;
        }
    }
