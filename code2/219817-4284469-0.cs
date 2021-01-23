    public static IQueryable<T> GetPage(this IQueryable<T> query,
        int skip, int take, out int count)
    {
        count = query.Count();
        return query.Skip(skip).Take(take);
    }
