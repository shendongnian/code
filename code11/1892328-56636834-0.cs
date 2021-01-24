    public static class Extensions
    {
        public static IQueryable<Coffee> GetPriceMoreThen(this IQueryable<Coffee> query, decimal moreThen)
        {
            return query.Where(c =>
                               c.Prices
                                .OrderByDescending(p => p.CreatedAt)
                                .First()
                                .Price >= moreThen);
        }
    }
