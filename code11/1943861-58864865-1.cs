c#
var query = 
    from category in db.Categories
        .Include(c => c.Products)
    select category;
This returns categories with their `Products` navigation properties loaded.
Lazy loading is triggered by accessing navigation properties in an already executed LINQ query result. for example:
c#
var query = db.Categories.ToList();
foreach (var c in query)
{
    Console.WriteLine("* {0}", c.categoryName);
    foreach (var p in c.Products) // <= new query triggered here.
    {
         Console.WriteLine("   - {0}", p.Name);
    }
};
For lazy loading to occur the navigation property should be defined as `virtual`:
c#
class Category
{
    public int CategoryID { get; set; }
    public String Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
Usually though, eager loading is preferred over lazy loading because it is less "chatty" to the database.
