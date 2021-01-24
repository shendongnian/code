    var lowestPriceCategories = DataLoader.LoadProducts()
        .GroupBy(x => x.Category)
        .Select(x => new
        {
            Category = x.Key,
            LowestPrice = x.OrderBy(y => y.UnitPrice).FirstOrDefault()
        });
        
