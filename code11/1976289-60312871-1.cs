    using(var context = new AppContext())
    {
        var sumObjects = context.Dealers
            .SelectMany(d => d.DealerCars)
            .GroupBy(c => c.Dealer.DealerName)
            .Select(g => new 
            {
                DealerName = g.Key,
                TotalCost = g.Sum(c => c.Cost)
            }).ToList();
    }
