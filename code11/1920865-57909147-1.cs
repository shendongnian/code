    public async Task<RepositoryResult> UpdateAsync(Product product) {
    {
        context.Products.Attach(product);
        context.Entry(product).Collection(p => p.PreparationMethods).Load(); 
        context.Entry(product).Collection(p => p.ProductAttributes).Load(); 
        context.Entry<Products>(product).State = System.Data.EntityState.Modified;
        await _context.SaveChangesAsync();
        return RepositoryResult.Success();
    }
