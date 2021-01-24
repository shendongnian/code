private IEnumerable<OutputResponse> GetOutput(IEnumerable<Item> items)
{
    return items.SelectMany(x => x.Products ?? Array.Empty<Product>)
                .Select(x => new ProductName(x))
                .Select(p => new OutputResponse() { Name = product.Name, Description = product.Description});
}
It will iterate twice over the whole collection but OP asked for LOC reduction and not performance improvement. 
