    static Expression<Func<Person, bool>> BuildAgePredicate(IEnumerable<AgeRange> ranges)
    {
        var predicate = PredicateBuilder.False<Person>();
        foreach (var r in ranges)
        {
            // To avoid capturing the loop variable
            var r2 = r;
            predicate = predicate.Or (p => p.Age >= r2.Min && p.Age <= r2.Max);
        }
        return predicate;
    }
