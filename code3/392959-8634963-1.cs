    var predicate = DelegatePredicateBuilder.False<string>();
    if (someCondition)
    {
        predicate = predicate.Or(l => l.StartsWith("S"));
    }
    if (someCondition)
    {
        predicate = predicate.Or(l => l.EndsWith("u"));
    }
    query = query.Where(predicate);
