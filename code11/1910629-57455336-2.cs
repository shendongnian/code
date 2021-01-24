    public async Task<IEnumerable<ProductDto>> GetProductsByDocumentTypeId(int id)
    {
        var dtos = await ProductRepository.GetProductsByDocumentType(id)
           .ProjectTo<ProductDto>().ToListAsync();
        return dtos;
    }
