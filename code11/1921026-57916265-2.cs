    foreach (var item in plist)
    {
        if (!pblist.Any(productBrand => productBrand.Id == item.Brand.Id))
        {
            pblist.Add(item.Brand);
        }
    };
