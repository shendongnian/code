    IQueryable<Car> query = ...
    if(!string.IsNullOrEmpty(search.make))
        query = query.Where(c => c.make == search.make);
    if(!string.IsNullOrEmpty(search.model))
        query = query.Where(c => c.model== search.model);
