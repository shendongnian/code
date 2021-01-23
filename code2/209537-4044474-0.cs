    static Expression<Func<Person, bool>> BuildAgePredicate(IEnumerable<AgeRange> ranges)
    {
        var predicate = PredicateBuilder.False<Person>();
        foreach (var r in ranges)
        {
            predicate = predicate.Or (p => p.Age >= r.Min && p.Age <= r.Max);
        }
        return predicate;
    }
