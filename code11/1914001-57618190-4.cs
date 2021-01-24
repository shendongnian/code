    public static class ExpressionTreesExtension {
        static readonly Type funcTTResult = typeof(Func<,>);
        public static IOrderedQueryable<T> OrderByProperty<T>(this IEnumerable<T> enumerable, string propertyName) {
            var itemType = typeof(T);
            var propertyInfo = itemType.GetProperty(propertyName);
            var propertyType = propertyInfo.PropertyType;
            // Func<T,TPropertyType>
            var delegateType = funcTTResult.MakeGenericType(itemType, propertyType);
            // T x =>
            var parameterExpression = Expression.Parameter(itemType, "x");
            // T x => x.Property
            var propertyAccess = Expression.Property(parameterExpression, propertyInfo);
            // Func<T,TPropertyType> = T x => x.Property
            var keySelector = Expression.Lambda(delegateType, propertyAccess, parameterExpression);
            var query = enumerable.AsQueryable();
            MethodCallExpression orderByExpression = Expression.Call(
                 typeof(Queryable),
                 "OrderBy",
                 new[] { query.ElementType, propertyInfo.PropertyType },
                 query.Expression, keySelector);
            // Create an executable query from the expression tree. 
            return (IOrderedQueryable<T>)query.Provider.CreateQuery<T>(orderByExpression);
        }
    }
