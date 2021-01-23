    public IQueryable<T> GetQuery<T>(FilterDefinition filter)
    {
        IQueryable<T> query = context.Set<T>();
        // assuming that you return all records when nothing is specified in the filter
        if (filter.FilterByName)
            query = query.Where(t => 
                t.Name >= filter.NameFrom && t.Name <= filter.NameTo);
        if (filter.FilterByQuantity)
            query = query.Where(t => 
                t.Name >= filter.QuantityFrom && t.Name <= filter.QuantityTo);
        return query;
    }
    
