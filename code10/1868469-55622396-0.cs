    var products = await _context.Products
        .Where(prod => prod.ProductTypeId == id)
        .Select(prod => new ProductDTO
        {
            ProductId = prod.ProductId,
            // rest of properties...
            // now get the parameters
            Parameters = prod.Parameters
                // assuming you want to order by value, the question isn't very clear
                .OrderBy(par => par.Value)
                .Select(par => new ParameterDTO
                {
                    Id = par.Id,
                    // etc
                })
                .ToList()
        })
        .ToListAsync();
