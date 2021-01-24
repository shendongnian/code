     public ProductsDto GetProductsDto(Products obj)
        {
            var dto = new ProductsDto();
            dto.SetDto(obj);
            return dto;
        }
    ----------------------------------------------------------
        var products = _RepositoryContext.Products.ToList();
        var productsDto = products?.Select(GetProductsDto);
