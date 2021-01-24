csharp
var products = await _context.Products.Where(x => x.IsDeleted == false)
                                       .Include(x => x.SubCategory)
                                       .ThenInclude(x => x.Category).ToListAsync()
2. Yes or no. It depends on what your `ViewModel` is.
Entity framework is a framework for operating database entities. But `ViewModel` is a concept in MVVM. It was two different concepts and have no relationship.
Usually, the view is rendering what is needed to be rendered. So we return it a `ViewModel` instead of `Entity`. If the `Entity` itself is what you need to be rendered, just return it! It's ok.
csharp
return View(viewName: "myview", model: products);
csharp
@model IEnumerable<Product> // Product is your entity in EF. You can use it in a view.
It's fine.
But, consider what the view needs is not what you got from entit-framework. Now you need to convert the entity to the `ViewModel`. For example:
var entity = await dbContext.MyTable.SingleOrDefaultAsync(t => t.Id == id);
var viewModel = new MyViewModel
{
    Color = entity.Color // Only need to return the color, for example.
}
return View(viewModel);
@model MyViewModel
<h2>The color of it is @Model.Color</h2>
@*You can't access other properties of the entity here in the view.*@
And the other properties will not be returned to the view.
And some tools like `AutoMapper` can just help you do the map job.
Another way is to use `Select()` to return the column on your choice. For example:
Entity definition and view model definition.
csharp
public class Product
{
    public int Id { get; set; } // Don't want to return this.
    public string Name { get; set; } // Only want to return this.
}
public class ProductDto
{
    public string Name { get; set; }
}
csharp
var products = _context.Products; // While the products is declared, the query was not happened in the database. It only defines an IQueryable object.
List<ProductDto> viewModel = await products.Select(t => new ProductDto
{
    Name = t.Name // Manually map here.
})
.ToListAsync();
return View(viewModel);
In your view:
@model List<ProductDto>
foreach (var dto in Model)
{
  <h2>dto.Name</h2>
}
