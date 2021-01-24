    IList<T> GetRecords<T>() where T : class
    {
        var hasNavigationPropertyInterface = typeof(IHasNavigationProperty).IsAssignableFrom(typeof(T));
        var query = _context.Set<T>().AsQueryable();
        if (hasNavigationPropertyInterface)
        {
            var navigationPropertyName = nameof(NavigationProp);
            query = query.Include(navigationPropertyName);
        }
        var recordList = query.AsNoTracking()
            .ToList();
        return recordList;
    }
