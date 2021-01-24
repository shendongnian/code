    using (var tigerContext = new TigerContext())
    {
        var stockRemaningList = 
    		from stocks in tigerContext.Stock
    		join item in tigerContext.ItemsSum on stocks.LOGICALREF equals item.STOCKREF  into tempJoin 
    		from leftJoined in tempJoin.DefaultIfEmpty()
    		group leftJoined by stocks into grouped
    		select new StocksRemaning
            {
                StockCode = grouped.Key.CODE,
                StockRef = grouped.Key.LOGICALREF,
                StockName = grouped.Key.NAME,
                ActualStock = grouped.Sum(i=>i.ONHAND)
            };
        return stockRemaningList.ToList();
    }
