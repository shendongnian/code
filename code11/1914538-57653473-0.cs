        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortProperty, ListSortDirection sortOrder)
        {
            var methodCallExpression = source.Expression as MethodCallExpression;
            var isOrdered = methodCallExpression != null 
                            && (methodCallExpression.Method.Name == "OrderBy" 
                                || methodCallExpression.Method.Name == "OrderByDescending" 
                                || methodCallExpression.Method.Name == "ThenBy" 
                                || methodCallExpression.Method.Name == "ThenByDescending");
            
            var type = typeof(T);
            var property = type.GetProperty(sortProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var typeArguments = new Type[] { type, property.PropertyType };
            var methodName = isOrdered
                ? (sortOrder == ListSortDirection.Ascending ? "ThenBy" : "ThenByDescending")
                : (sortOrder == ListSortDirection.Ascending ? "OrderBy" : "OrderByDescending");
            var resultExp = Expression.Call(typeof(Queryable), methodName, typeArguments, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }
