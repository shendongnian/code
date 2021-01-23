    public static class OrderByCollection
    {
        // that's extension method
        // it should be static
        public static IQueryable<T> ExecuteOrderBys<T>(this IQueryable<T> source)
        {
        }
    }
