    public static DateTime GetMostRecentTimestamp<T>(this IQueryable<T> queryable)
        where T : ITimestamp
    {
         return queryable.Select(x => x.m_Timestamp)
                .OrderByDescending(r => r)
                .FirstOrDefault()
    }
