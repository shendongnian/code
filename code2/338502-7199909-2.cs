    var appleStock = new Stock { Name = "Apple", Symbol = "APPL" };
    appleStock.Prices.Add(new Price { Date = new DateTime(8, 23, 2011), Price = 199.43 });
    appleStock.Prices.Add(new Price { Date = new DateTime(8, 25, 2011), Price = 206.28 });
    stocks.Add(appleStock);
    var googleStock = new Stock { Name = "Google", Symbol = "GOOG" };
    googleStock.Prices.Add(/* same as above */);
    stocks.Add(googleStock);
