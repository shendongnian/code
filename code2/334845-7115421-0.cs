    public static IQueryable<Item> _GroupMaxs(this IQueryable<Item> list)
    {
        return list.GroupBy(x => x.Family)
            .Select(g => g.OrderByDescending(x => x.Value).First());
    }
