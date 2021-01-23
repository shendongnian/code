     this works
    public static IQueryable<T> SearchBy<T>(this IQueryable<T> source, SearchCriteria criteria)
        {
            //throw an error if the source is null
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            ParameterExpression parameter = Expression.Parameter(source.ElementType, string.Empty);
            BinaryExpression property = Expression.Equal(Expression.PropertyOrField(parameter, criteria.Property), Expression.Constant(criteria.PropertyValue));
            LambdaExpression lambda = Expression.Lambda(property, parameter);
            Expression methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                                new Type[] { source.ElementType },
                                                source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
