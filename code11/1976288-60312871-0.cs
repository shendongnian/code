    List<Dealer> dealers = loadDealers(); // Load these from data source.
    var sumObjects = dealers
        .SelectMany(d => d.DealerCars)
        .GroupBy(c => c.Dealer.DealerName)
        .Select(g => new 
        {
            DealerName = g.Key,
            TotalCost = g.Sum(c => c.Cost)
        }).ToList();
