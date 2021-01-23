    var grouped =
        RewardTransctions.GroupBy(t => t.PurchaseDate.Value.Month).Select(
            g => new TransactionDetail { Month = g.Key, TransactionAmount = g.Count() }).ToList();
    for (var i = 1; i <= 12; ++i)
    {
        if (grouped.Count(x => x.Month == i) == 0)
        {
            grouped.Add(new TransactionDetail { Month = i, TransactionAmount = 0 });
        }
    }
