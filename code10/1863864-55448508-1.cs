       var EntryProduct = _context.Products.Find(ProductDTO.ProductId);
        if (EntryProduct != null)
            return ProductDTO;
        var product = new Product
        {
            Id = ProductDTO.ProductId,
            Number = ProductDTO.Number,
            Amount = ProductDTO.Amount,
            PrimeCostEUR = ProductDTO.PrimeCostEUR,
        };
        var parameterIds = ParameterDTO.Select(x => x.Id).ToList();
        var parametersToAdd = context.Parameters
            .Where(x => parameterIds.Contains(x.ParameterId))
            .Select(x => new ProductParameter
            {
                Product = product,
                Parameter = x
            }).ToList();
        product.ProductParameters.AddRange(parametersToAdd);
        await _context.SaveChangesAsync();
        return ProductDTO;
