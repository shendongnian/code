    context.ProductColors
        .Select(x => new {ProductName = x.Product.Name, ColorName = x.Color.Name})
        .GroupBy(x => x.ProductName)
        .Select( group => new 
        {
            ProductName = group.Key, // Product.Name
            Colours = string.Join(", ", group.Select(x=> x.ColourName)); // Colour.Names
        }).ToList();
     
