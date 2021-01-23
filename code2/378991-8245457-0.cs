    var predicate = PredicateBuilder.False<User>();
    if (condition1.HasValue)
    {
      predicate = predicate.Or(x => x.Condition1 == condition1.Value);
    }
    if (condition2.HasValue)
    {
      predicate = predicate.Or(x => x.Condition2 == condition2.Value);
    }
    return Database.Set<User>().Where(predicate);
