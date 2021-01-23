    private IQueryable<LogEntry> SelectAll<T>(IEnumerable<LogEntry> logEntries,
        List<Expression<Func<LogEntry, bool>>> filters)
    {
        var selectAllQuery = logEntries.AsQueryable();
        if (filters != null)
        {
            foreach (var filter in filters)
            {
                selectAllQuery = selectAllQuery.Where(filter);
            }
        }
        return selectAllQuery;
    }
