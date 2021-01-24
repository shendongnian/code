    var lowestPriceCategories = DataLoader.LoadProducts()
        .GroupBy(x => x.Category)
        .Select(x => new
        {
            Category = x.Key,
            LowestPrice = x.Min(y => y.UnitPrice)
        });
        
