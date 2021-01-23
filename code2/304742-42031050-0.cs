    private static Action<TObject> CreateClearStringProperties<TObject>()
    {
        var memberAccessExpressions = new List<System.Linq.Expressions.Expression>();
        System.Linq.Expressions.ParameterExpression arg = System.Linq.Expressions.Expression.Parameter(typeof(TObject), "x");
        foreach (var propertyInfo in typeof(TObject).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy))
        {
            if (propertyInfo.PropertyType == typeof(string) && propertyInfo.SetMethod != null)
            {
                var memberAccess = System.Linq.Expressions.Expression.MakeMemberAccess(arg, propertyInfo);
                var assignment = System.Linq.Expressions.Expression.Assign(memberAccess, System.Linq.Expressions.Expression.Constant(string.Empty));
                memberAccessExpressions.Add(assignment);
            }
        }
        foreach (var fieldInfo in typeof(TObject).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.FlattenHierarchy))
        {
            if (fieldInfo.FieldType == typeof(string))
            {
                var memberAccess = System.Linq.Expressions.Expression.MakeMemberAccess(arg, fieldInfo);
                var assignment = System.Linq.Expressions.Expression.Assign(memberAccess, System.Linq.Expressions.Expression.Constant(string.Empty));
                memberAccessExpressions.Add(assignment);
            }
        }
        if (memberAccessExpressions.Count == 0)
            return new Action<TObject>((e) => { });
        var allProperties = System.Linq.Enumerable.Aggregate(memberAccessExpressions, System.Linq.Expressions.Expression.Block);
        return System.Linq.Expressions.Expression.Lambda<Action<TObject>>(allProperties, arg).Compile();
    }
