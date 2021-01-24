    ...
    item = (BidAskCurves)serializer.Deserialize(reader);
    
    foreach (var ts in item.MarketArea.DeliveryDay.TimeStep)
    {
        BidAskCurvesData bidAskCurvesData = new BidAskCurvesData
        {
            ReportID = 123,
            MarketAreaName = item.MarketArea.MarketAreaName,
            Day = item.MarketArea.DeliveryDay.Day,
            TimeSetID = ts.TimeStepID,
            PurchasePrice = ts.Purchase[0].Price,
            PurchaseVolume = ts.Purchase[0].Volume,
            SellPrice = ts.Sell[0].Price,
            SellVolume = ts.Sell[0].Volume
        };
    
        using (SEMOContext context = new SEMOContext())
        {
            context.BidAskCurvesReports.Add(item);
            context.SaveChanges();
        }
    }
