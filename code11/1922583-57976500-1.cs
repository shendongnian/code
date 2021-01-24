    var query = DB.Prouducts.Where(x=> x.brandName == brand);
    if (category != null)
    {
         query = query.Where(x => x.catName == category);
    }
    if (price != 0)
    {
        query = query.Where(x => x.price == price)
    }
    
    sortedData = query.ToList();
