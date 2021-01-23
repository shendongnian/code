    public static R NullPropagate<T, R>(this T source, Expression<Func<T, R>> expression, R defaultValue)
    {
        var safeExp = Expression.Lambda<Func<T, R>>(
            WrapNullSafe(expression.Body, Expression.Constant(defaultValue)),
            expression.Parameters[0]);
    
        var safeDelegate = safeExp.Compile();
        return safeDelegate(source);
    }
    
    private static Expression WrapNullSafe(Expression expr, Expression defaultValue)
    {
        Expression obj;
        Expression safe = expr;
    
        while (!IsNullSafe(expr, out obj))
        {
            var isNull = Expression.Equal(obj, Expression.Constant(null));
    
            safe = Expression.Condition (isNull, defaultValue, safe);
    
            expr = obj;
        }
        return safe;
    }
    
    private static bool IsNullSafe(Expression expr, out Expression nullableObject)
    {
        nullableObject = null;
    
        if (expr is MemberExpression || expr is MethodCallExpression)
        {
            Expression obj;
            MemberExpression memberExpr = expr as MemberExpression;
            MethodCallExpression callExpr = expr as MethodCallExpression;
    
            if (memberExpr != null)
            {
                // Static fields don't require an instance
                FieldInfo field = memberExpr.Member as FieldInfo;
                if (field != null && field.IsStatic)
                    return true;
    
                // Static properties don't require an instance
                PropertyInfo property = memberExpr.Member as PropertyInfo;
                if (property != null)
                {
                    MethodInfo getter = property.GetGetMethod();
                    if (getter != null && getter.IsStatic)
                        return true;
                }
                obj = memberExpr.Expression;
            }
            else
            {
                // Static methods don't require an instance
                if (callExpr.Method.IsStatic)
                    return true;
    
                obj = callExpr.Object;
            }
    
            // Value types can't be null
            if (obj.Type.IsValueType)
                return true;
    
            // Instance member access or instance method call is not safe
            nullableObject = obj;
            return false;
        }
        return true;
    }
