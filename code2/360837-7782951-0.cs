    var predicate = q => !q.Hidden;
    if (!string.IsNullOrWhiteSpace(searchToken))
    {
        predicate = predicate.And(q => q.Name.ToUpper()
                                             .Contains(searchToken.ToUpper());
    }
    return predicate;
