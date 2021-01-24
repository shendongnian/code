private IEnumerable<OutputResponse> GetOutput(IEnumerable<Item> items)
{    
    var results=items.SelectMany(item=>item.Products ?? Enumerable.Empty<Product>())
                     .Select(p=>new ProductName(p))
                     .Select(pn=>new OutputResponse {    
                                      Name=pn.Name, 
                                      Description=pn.Description
                            });
    return results;
}
or
private IEnumerable<OutputResponse> GetOutput(IEnumerable<Item> items)
{        
    var results =from item in items
                 from p in item.Products ?? Enumerable.Empty<Product>()
                 let pn=new ProductName(p)
                 select new OutputResponse {
                             Name=pn.Name,
                             Description=pn.Description
                 };
    return results;
}
As everyone else mentioned though, that `ProductName` seems to have no purpose.
Writing those queries requires some guessing and assumptions though, eg what each class contains, and what *Products* contains. I assume the classes involved looks something like this :
class OutputResponse 
{ 
    public string Name;
    public string Description;
}
class ProductName
{
    public string Name;
    public string Description;
    
    public ProductName(Product x)=>(Name,Description)=(x.Name,x.Description);
}
class Product
{ 
    public string Name;
    public string Description;
}
class Item
{
    public List<Product> Products;
}
