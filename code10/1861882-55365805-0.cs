public class Product
{
   public string ProductName { get; set; }
   public decimal Emv { get; set; }
}
What you want in the end is to find the sum of the `Emv` _per each `ProductName`_.
public Dictionary<string, decimal> SumProductEmv(IEnumerable<Product> allProducts)
{
    return allProducts
        .GroupBy(product => product.ProductName)
        .Select(group => new
        {
            ProductName = group.Key, // this is the value you grouped on - the ProductName
            EmvSum = group.Sum(item => item.Emv)
        })
        .ToDictionary(x => x.ProductName, x => x.EmvSum);
}
The trick here is the when you are doing the `Sum` operation, it's against the `group`.
In this example I'm packaging the results into a dictionary for convenience. The key is the name of a product, and the value is the sum of all Emv values for products with that name.
