    private static object GetArgumentValue(Expression element)
    {
        if (element is ConstantExpression)
        {
            return (element as ConstantExpression).Value;
        }
        var l = Expression.Lambda(Expression.Convert(element, element.Type));
        return l.Compile().DynamicInvoke();
    }
