    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderByPropertyOrField<T>(this IQueryable<T> queryable,
          string propertyOrFieldName, bool ascending = true)
        {
            var parameter = Expression.Parameter(queryable.ElementType, "x");
            var selector = Expression.PropertyOrField(parameter, propertyOrFieldName);
            var getLength = Expression.PropertyOrField(selector, "Length");
            var orderByLength = CreateOrderExpression(parameter,
              typeof(int),
              queryable.Expression, // order source collection
              getLength,
              ascending ? "OrderBy" : "OrderByDescending");
            
            var orderByValue = CreateOrderExpression(parameter,
              typeof(string),
              orderByLength, // order previous collection
              selector,
              ascending ? "ThenBy" : "ThenByDescending");
            return queryable.Provider.CreateQuery<T>(orderByValue);
        }
        private static Expression CreateOrderExpression(ParameterExpression parameter, Type keyType, Expression collection, Expression selector, string methodName)
        {
            return Expression.Call(
                typeof(Queryable),
                methodName,
                new[] { parameter.Type, keyType },
                collection,
                Expression.Lambda(selector, parameter)
            );
        }
    }
