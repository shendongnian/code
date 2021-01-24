    var lowestPriceCategories = DataLoader.LoadProducts()
        .GroupBy(x => x.Category)
        .Select(x => new
        {
            Category = x.Key,
            LowestPrice = x.FirstOrDefault(y => y.UnitPrice == x.Min(z => z.UnitPrice))
        });
        
