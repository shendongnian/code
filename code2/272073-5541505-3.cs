    public IQueryable<SomeEntity> GetQuery(FilterDefinition filter)
    {
        IQueryable<SomeEntity> query = context.Set<SomeEntity>();
        // assuming that you return all records when nothing is specified in the filter
        if (filter.FilterByName)
            query = query.Where(t => 
                t.Name >= filter.NameFrom && t.Name <= filter.NameTo);
        if (filter.FilterByQuantity)
            query = query.Where(t => 
                t.Quantity >= filter.QuantityFrom && t.Quantity <= filter.QuantityTo);
        return query;
    }
    
