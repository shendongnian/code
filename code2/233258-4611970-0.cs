    public static IQueryable<T> Like<T>(this IQueryable<T> source, string propertyName, string keyword) {
        Type type = typeof(T);
        ParameterExpression parameter = Expression.Parameter(type, "param");
        MemberExpression memberAccess = Expression.MakeMemberAccess(parameter, type.GetProperty(propertyName));
        ConstantExpression constant = Expression.Constant("%" + keyword + "%");
        MethodInfo contains = memberAccess.Type.GetMethod("Contains");
        MethodCallExpression methodExp = Expression.Call(memberAccess, contains, Expression.Constant(keyword));
        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(methodExp, parameter);
        return source.Where(lambda);
    }
