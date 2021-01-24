    public async Task<IEnumerable<ProductDto>> GetProductsByDocumentTypeId(int id)
    {
        var products = await ProductRepository.GetProductsByDocumentType(id);
        var dtos = await products.Select(x => Mapper.Map<ProductDto>(x)).ToListAsync();
        return dtos;
    }
