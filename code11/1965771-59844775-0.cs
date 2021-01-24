private IEnumerable<OutputResponse> GetOutput(IEnumerable<Item> items)
{
    var products = items
        .SelectMany(x => x.Products
                .Where(p => p != null)
                .Select(p => new ProductName(p)));
    foreach (var product in products)
    {
        yield return new OutputResponse
        {
            Name = product.Name,
            Description = product.Description
        };
    }
}
Here you can see that I've encompassed the logic in a linq statement.
I am looping through the items to get the products, looping through products to get the ones that are not `null` looping again to convert the products into product names (may want to ask yourself if this is nessasary, seeing as the information that you need to create an `OutputResponse` is on the `Product` class, could save yourself a potential looping.
Hope this makes sense.
