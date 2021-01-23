    List<Stock> stocks;
    Parallel.ForEach(stocks, 
                     new ParallelOptions() { MaxDegreeOfParallelism = 5 }, 
                     (stock) =>
    {
        float newPrice = UpdatePrice(stock.TickerSymbol); //web service call
        stock.Price = newPrice;
    });
