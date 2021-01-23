    var predicate = PredicateBuilder.True<Customer>();
    if (searchingFirstName)
    {
        predicate = predicate.And(cust => cust.First == firstName);
    }
    if (searchingInterests)
    {
        var subpredicate = PredicateBuilder.False<Customer>();
        foreach (var interest in interests)
        {
            subpredicate = subpredicate.Or(cust =>
                cust.Interests.Contains(interest));
        }
        predicate = predicate.And(subpredicate);
    }
    var query = Context.Customers.AsExpandable().Where(predicate);
