    public static class QueryableExtensions
    {
        public enum SortDirection { ASC,DESC}
        static LambdaExpression CreateExpression(Type type, string propertyName)
        {
            var param = Expression.Parameter(type, "x");
            Expression body = param;
            body = propertyName.Split('.')
                .Select(prop => body = Expression.PropertyOrField(body, prop))
                .Last();
            return Expression.Lambda(body, param);
        }
        public static IQueryable<T> SortBy<T>(this IQueryable<T> source,string expressionField,SortDirection sortDirection = SortDirection.ASC)
        {
            var lambdaExpression = CreateExpression(typeof(T), expressionField) as dynamic;
            return sortDirection == SortDirection.ASC ? Queryable.OrderBy(source,lambdaExpression) : Queryable.OrderByDescending(source, lambdaExpression);
        }
        
    }
