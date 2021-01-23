    var sorted = products
        .Select(
            p => new
            {
                Product = p,
                Categories = p.Categories.OrderBy(c => c.Name)
            }
        )
        .OrderBy(x => x.Product.Name);
