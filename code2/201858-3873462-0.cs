    public IEnumerable<Store> ListStores(Func<Store, string> sort, bool desc, int page, int pageSize, out int totalRecords)
    {
        var context = new TectonicEntities();
        var results = context.Stores;
        totalRecords = results.Count();
        int skipRows = (page - 1) * pageSize;
        if (desc)
            results = results.OrderByDescending(sort);
        return results.Skip(skipRows).Take(pageSize).ToList();
    }
