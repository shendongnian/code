        public static IOrderedQueryable<T> Sort<T>(this IQueryable<T> query, string sort) where T : class
        {
            Type type = typeof(T);
            ParameterExpression param = Expression.Parameter(type, "x");
            var (isDescending, normalizedSortParam) = NormalizeSortParam(sort);
            MemberExpression propertyExpression;
            try
            {
                propertyExpression = Expression.PropertyOrField(param, normalizedSortParam);
            }
            catch(ArgumentException)
            {
                propertyExpression = Expression.Property(param, "Id");
            }
            Type outputType = propertyExpression.Type;
            LambdaExpression filterExpression = Expression.Lambda(propertyExpression, param);
            // Call OrderBy or OrderByDescending on original query expression
            MethodCallExpression orderedExpression = Expression.Call(
                typeof(Queryable),
                isDescending ? "OrderByDescending" : "OrderBy",
                new []{ typeof(T), outputType },
                new [] { query.Expression, filterExpression }
            );
            
            // Create new query from orderedExpression 
            return (IOrderedQueryable<T>)query.Provider.CreateQuery<T>(orderedExpression);
        }
