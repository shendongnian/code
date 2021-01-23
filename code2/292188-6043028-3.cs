    public static string GetPropertyName<TSource, TResult>(
        Expression<Func<TSource, TResult>> propertyExpression)
    {
        return (propertyExpression.Body as MemberExpression).Member.Name;
    }
