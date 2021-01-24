    IQueryable<Entity1, Entity2> query = //some query with joins
    
    if (something)
    {
         query = query.Where(some conditions here);
    }
    else
    {
         query = query.Where(some other conditions);
    }
    return query.Distinct().ToList();
