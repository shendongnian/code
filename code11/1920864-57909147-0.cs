    public async Task<RepositoryResult> UpdateAsync(Product product) {
    {
        context.Products.Attach(product);
        context.Entry<Products>(product).State = System.Data.EntityState.Modified;
    
        await _context.SaveChangesAsync();
        return RepositoryResult.Success();
    }
