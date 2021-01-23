    var query = Database.Set<User>();
    if (condition1.HasValue)
    {
        query = query.Where(x => x.Condition1 == condition1.Value);
    }
    if (condition2.HasValue)
    {
        query = query.Where(x => x.Condition2 == condition2.Value);
    }
    ...
    return query.ToList();
