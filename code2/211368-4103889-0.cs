    var gcs = gge.GiftCards
        .Select(gc => gc.OwnerId)
        .ToDictionary(x => x.OwnerId.ToString(), x => x);
    
    var gcIds = gcs.Keys.ToArray();
    
    var results = (
        from p in gge.Customers
        where gcIds.Contains(p.customer_Key)
        select p)
        .ToArray()
        .GroupBy(p => p.customer_Key)
        .Select(p => new MyCardViewModel
            {
                GiftCard = gcs[p.Key],
                Customers = p.ToArray(),
            });
