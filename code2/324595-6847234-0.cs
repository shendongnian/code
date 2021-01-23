    IQueryable<T> query = dbContext.SomeObjectSet;
    if (condition1) {
        query = query.Where(...)
    }
    if (condition2) {
        query = query.Where(...)
    }
