    public static IQueryable<T> TraceSql(this IQueryable<T> query)
    {
        var sql = ((System.Data.Objects.ObjectQuery)query).ToTraceString();
        // do whatever logging of sql you want here, eg (for web)
        // (view by visiting trace.axd within your site)
        HttpContext.Current.Trace.Write("sql", sql);
        return query;
    }
