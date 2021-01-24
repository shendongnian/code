    private IList<T> GetRecords<T>() where T : class
    {
        var hasProperty = typeof(T).GetProperty(nameof(NavigationProp)) != null;
        var query = _context.Set<T>().AsQueryable();
        if (hasProperty)
        {
            var navigationPropertyName = nameof(NavigationProp);
            query = query.Include(navigationPropertyName);
        }
        var recordList = query.AsNoTracking()
            .ToList();
        return recordList;
    }
