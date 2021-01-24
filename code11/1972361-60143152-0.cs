    var sars = context.StockAppreciationRights.Select(x => new SARSummary
    {
        UbsId = x.UbsId,
        Units = x.Units,
        VestDate = x.VestDate,
        GrantDate = x.Sar.GrantDate,
        ExpirationDate = x.Sar.ExpirationDate,
        UnitsGranted = x.Sar.UnitsGranted,
        GrantPrice = x.Sar.GrantPrice
    }).ToList();
