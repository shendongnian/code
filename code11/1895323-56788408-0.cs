    public IOrderedQueryable<T> SortQuery(IQueryable<T> query, Dictionary<string, char> sorts)
    {
        var count = 0;
        var orderedQuery = query.OrderBy(x => true); // This is the fix!
        foreach (var s in sorts)
            if (!string.IsNullOrWhiteSpace(s.Key) && new[] {'A', 'D'}.Contains(char.ToUpper(s.Value)))
                orderedQuery = orderedQuery.OrderBy(this.SortFields[s.Key], char.ToUpper(s.Value) == 'D', count++ == 0);
        return orderedQuery;
    }
