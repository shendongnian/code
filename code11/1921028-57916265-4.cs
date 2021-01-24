    foreach (var item in plist)
    {
        // Note: you could potentially use 'Name' instead of 'Id'
        if (!pblist.Any(productBrand => productBrand.Id == item.Brand.Id))
        {
            pblist.Add(item.Brand);
        }
    }
