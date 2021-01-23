        IQueryable<T> queryableData = (Items as IList<T>).AsQueryable<T>();
        PropertyInfo propInfo = typeof(T).GetProperty("Title");
        ParameterExpression pe = Expression.Parameter(typeof(T), "Title");
        Expression left = Expression.Property(pe, propInfo);
        Expression right = Expression.Constant("Bob", propInfo.PropertyType);
        Expression predicateBody = Expression.Equal(left, right);
        // Create an expression tree that represents the expression            
        MethodCallExpression whereCallExpression = Expression.Call(
            typeof(Queryable),
            "Where",
            new Type[] { queryableData.ElementType },
            queryableData.Expression,
            Expression.Lambda<Func<T, bool>>(predicateBody, new ParameterExpression[] { pe }));
        T[] filtered = queryableData.Provider.CreateQuery<T>(whereCallExpression).Cast<T>().ToArray();
