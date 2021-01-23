    var query = from it in DataContext.Items
        where it.ThingId == thing.ThingId
        select new
        {
            it.Something,
            it.SomethingElse,
            it.AnotherSomething,
            it.Decimal
        };
    
    GridView.DataSource = from it in query.AsEnumerable()
        select new
        {
            it.Something,
            it.SomethingElse,
            it.AnotherSomething,
            Currency = it.Decimal.ToString("C")
        };
