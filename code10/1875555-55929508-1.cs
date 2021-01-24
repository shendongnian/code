    return context.Products
        .Where(x => x.IsActive)
        .Select(x => new ProductViewModel
        {
            ProductId = x.ProductId,
            Name = x.Name,
            Price = x.Price
        }).ToList();
