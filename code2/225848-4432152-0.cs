    public static string Property<TModel, TProperty>(this TModel model, Expression<Func<TModel, TProperty>> property)
    {
        var memberExpression = property.Body as MemberExpression;
        return memberExpression.Member.Name;
    }
