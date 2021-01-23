        public static IQueryable<T> Has<T>(this IQueryable<T> source, string propertyName, string keyword)
        {
            if (source == null || propertyName.IsNull() || keyword.IsNull())
            {
                return source;
            }
            keyword = keyword.ToLower();
            var parameter = Expression.Parameter(source.ElementType, String.Empty);
            var property = Expression.Property(parameter, propertyName);
            var CONTAINS_METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var TO_LOWER_METHOD = typeof(string).GetMethod("ToLower", new Type[] { });
            var toLowerExpression = Expression.Call(property, TO_LOWER_METHOD);
            var termConstant = Expression.Constant(keyword, typeof(string));
            var containsExpression = Expression.Call(toLowerExpression, CONTAINS_METHOD, termConstant);
            var predicate = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
            var methodCallExpression = Expression.Call(typeof(Queryable), "Where",
                                        new Type[] { source.ElementType },
                                        source.Expression, Expression.Quote(predicate));
            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
