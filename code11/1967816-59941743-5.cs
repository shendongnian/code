    static public bool Method<T>(Expression<Func<T>> expression)
    {
        var memberExp = (MemberExpression)expression.Body;
        var propertyInfo = memberExp.Member as PropertyInfo;
        var propertyExpression = memberExp.Expression as MemberExpression;
        var targetObject = ((FieldInfo)propertyExpression.Member).GetValue((propertyExpression.Expression as ConstantExpression).Value);
        Console.WriteLine("Old value is {0}", propertyInfo.GetValue(targetObject));
        if (SomeCondition1)
        {
            propertyInfo.SetValue(targetObject, null);
            return false;
        }
    }
