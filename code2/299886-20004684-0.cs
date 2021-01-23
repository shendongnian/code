    if (input == null)
        return input;
    var field = input.Member as FieldInfo;
    var prope = input.Member as PropertyInfo;
    if ((field != null && field.FieldType.IsSubclassOf(typeof(Expression))) ||
        (prope != null && prope.PropertyType.IsSubclassOf(typeof(Expression))))
        return Visit(Expression.Lambda<Func<Expression>>(input).Compile()());
    return input;
