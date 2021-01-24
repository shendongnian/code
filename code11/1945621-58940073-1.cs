    private IQueryable<TEntity> Filter(IQueryable<TEntity> query, string value)
    {
        if (string.IsNullOrEmpty(value) || this.filterProps.Count == 0) return query;
        ConstantExpression constant = Expression.Constant(value.ToLower());
        ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "e");
        MemberExpression[] members = new MemberExpression[filterProps.Count()];
        MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        MethodInfo toLowerMethod = typeof(string).GetMethod("ToLower", System.Type.EmptyTypes);
            
        for (int i = 0; i < filterProps.Count(); i++)
        {
            members[i] = Expression.Property(parameter, filterProps[i]);
        }
        Expression predicate = null;
        foreach (var member in members)
        {
            //e => e.Member != null
            BinaryExpression notNullExp = Expression.NotEqual(member, Expression.Constant(null));
            //e => e.Member.ToLower() 
            MethodCallExpression toLowerExp = Expression.Call(member, toLowerMethod);
            //e => e.Member.Contains(value)
            MethodCallExpression containsExp = Expression.Call(toLowerExp, containsMethod, constant);
            //e => e.Member != null && e.Member.Contains(value)
            BinaryExpression filterExpression = Expression.AndAlso(notNullExp, containsExp);
            predicate = predicate == null ? (Expression)filterExpression : Expression.OrElse(predicate, filterExpression);
        }
        var lambda = Expression.Lambda<Func<TEntity, bool>>(predicate, parameter);
        return query.Where(lambda);
    }
