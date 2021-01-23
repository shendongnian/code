    private void UpdateNew(MarketProduct marketproduct)
    {
        MarketProduct dbProd = context.MarketProducts
            .Include(p => p.Categories)
            .SingleOrDefault(p => p.Id == marketproduct.Id);
        var categories = marketproduct.Categories 
                         ?? Enumerable.Empty<MarketCategory>();
        foreach (var category in categories)
        {
            if (!dbProd.Categories.Any(c => c.Id == category.Id))
            {
                // means: category is new
                context.MarketCategories.Attach(category);
                dbProd.Categories.Add(category);
            }
        }
        foreach (var category in dbProd.Categories.ToList())
        {
            if (!categories.Any(c => c.Id == category.Id))
                // means: category has been removed
                dbProd.Categories.Remove(category);
        }
        context.Entry(dbProd).CurrentValues.SetValues(marketproduct);
        // context.SaveChanges() somewhere
    }
