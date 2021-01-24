    return ((Expression<Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>>)(p => (IOrderedQueryable<TEntity>)Expression.Call(
                typeof(Queryable), 
                methodName, 
                new Type[2]
                {
                    type,
                    propertyType
                },
                parameterExpression2,
                Expression.Quote((Expression)lambdaExpression)
                ))).Compile();
