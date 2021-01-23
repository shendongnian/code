    public static string GetPropertyName<T>(Expression<Func<T>> expression)
    {
        MemberExpression propertyExpression = (MemberExpression)expression.Body;
        MemberInfo propertyMember = propertyExpression.Member;
 
        Object[] displayAttributes = propertyMember.GetCustomAttributes(typeof(DisplayAttribute), true);
        if(displayAttributes != null && displayAttributes.Length == 1)
            return ((DisplayAttribute)displayAttributes[0]).Name;
        return propertyMember.Name;
    }
