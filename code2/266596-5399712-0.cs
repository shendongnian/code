    public static partial class FooTable
    {
        public static IQueryable<FooTable> LastUpdated(this IQueryable<FooTable> queryable, int count)
        {
            return queryable.Where(x => (x.LastUdate != null))
                .OrderByDescending(x => x.LastUdate)
                .Take(count);
        }
    }
