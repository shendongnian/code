    private static SubSonic.Where ParseFilter(BinaryExpression expression)
    {
        var columnNameMethod = (MethodCallExpression)expression.Left;
        var columnNameExpression = columnNameMethod.Arguments[0];
        var parameterValueExpression = expression.Right;
        
        string columnName = GetValue<string>(columnNameExpression);
        object parameterValue = GetValue<object>(parameterValueExpression);
        Where result = CreateWheteFilterDummy(columnName, parameterValue);
        return result;
    }
    private static Where CreateWheteFilterDummy(string columnName, object parameterValue)
    {
        SubSonic.Where result = new Where();
        result.ColumnName = columnName;
        result.ParameterValue = parameterValue;
        return result;
    }
    private static T GetValue<T>(Expression columnNameExpression)
    {
        var columnNameObjectMember = Expression.Convert(columnNameExpression, typeof(T));
        var columnNameGetter = Expression.Lambda<Func<T>>(columnNameObjectMember);
        return columnNameGetter.Compile()();
    }
