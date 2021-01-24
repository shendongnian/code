    public async Task<IEnumerable<ProductDto>> TestProducts()
    {
        var items = await _context.Products.Select(p => new ProductDto
             {
                 ProductId= p.ProductId,
                 Number= p.Number,
                 Amount= p.Amount,
                 PrimeCostEUR= p.PrimeCostEUR,
                 ProductTypeName = p.ProductType.NameType
             }).ToListAsync();
        return items;
    }
