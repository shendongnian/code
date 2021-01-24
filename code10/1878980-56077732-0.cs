    public static class IQueryableExtensions
    {
        public static T TakeLast<T>(this IQueryable<T> input) where T : class, IIDentity
        {
            return input
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();
        }
    }
