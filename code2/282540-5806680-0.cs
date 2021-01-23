    public static IEnumerable<Document> GetMostRecentTimestamp (this IEnumerable<Document> docs)
    {
        return docs.Select(r => r.m_Timestamp)
                   .OrderByDescending(r => r)
                   .FirstOrDefault();
    }
