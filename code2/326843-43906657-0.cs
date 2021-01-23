    // First we create an Expression. Since we can't create an empty one,
    // we make it return false, since we'll connect the subsequent ones with "Or".
    // The following could also be: Expression<Func<Location, bool>> condition = (x => false); 
    // but this is clearer.
    var condition = PredicateBuilder.Create<Location>(x => false);
    foreach (var key in keys)
    {
        // each one returns a new Expression
        condition = condition.Or(
            x => x.Country == key.Country && x.City == key.City && x.Address == key.Address
        );
    }
    using (var ctx = new MyContext())
    {
        var locations = ctx.Locations.Where(condition);
    }
