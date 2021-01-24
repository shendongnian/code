var SubList = (from c in _context.Product
                           where (c.Id == Productid)
                           select new productDto
                           {
                               SubProduct = c.SubProduct,
                           }).ToList().Distinct();
            foreach (var subproductVal in SubList)
            {
                String subproduct = subproductVal.SubProduct;
                var productList = (from c in _context.Product
                                   orderby c.ProductName descending
                                           where (c.SubProduct == subproduct)
                                   select new {
                                       c.ProductName,
                                       c.ProductId 
                                     ).Distinct().ToArray();
                 await _context.SaveChangesAsync();
                ...
             }
Then your `productList` is a array of anonymous type where every element of array is object of anonymous type.
Also you may add some class:
public class ProductInfo
{
   public int ProductId {get;set;}
   public string ProductName {get;set;}
}
Then your code looks like:
...
var productList = (from c in _context.Product
                                   orderby c.ProductName descending
                                           where (c.SubProduct == subproduct)
                                   select new ProductInfo {
                                       ProductName = c.ProductName,
                                       ProductId = c.ProductId 
                                     ).Distinct().ToArray();
...
Then each element of `productList` array is a object of class `ProductInfo`. 
