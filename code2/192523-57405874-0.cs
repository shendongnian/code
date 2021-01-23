    public static class QueryableExtensions
    {
        public static IQueryable<TSource> OfType<TSource>(this IQueryable<TSource> queryable,
            Type runtimeType)
        {
            var method = typeof(Queryable).GetMethod(nameof(Queryable.OfType));
            var generic = method.MakeGenericMethod(new[] { runtimeType });
            return (IQueryable<TSource>)generic.Invoke(null, new[] { queryable });
        }
    }
