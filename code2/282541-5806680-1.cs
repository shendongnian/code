    public static DateTime GetMostRecentTimestamp (this IQueryable<Document> docs)
    {
        return docs.Select(r => r.m_Timestamp)
                   .OrderByDescending(r => r)
                   .FirstOrDefault();
    }
