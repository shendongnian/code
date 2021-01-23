    public static class EnumerableExtensions
    {
        public static IEnumerable<T> OrderByMany<T>(this IEnumerable<T> enumerable, 
            params Expression<Func<T, object>>[] expressions)
        {
            if (expressions.Length == 1)
                return enumerable.OrderBy(expressions[0].Compile());
    
            var query = enumerable.OrderBy(expressions[0].Compile());
            for (int i = 1; i < expressions.Length;i++)
            {
                query = query.ThenBy(expressions[i].Compile());
            }
            return query;
    
        }
    }
