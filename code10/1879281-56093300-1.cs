language=cs
public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
However, your final **DTO** may only have one or two of those properties, for example:
language=cs
public class AbstractProductListItemDto
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
}
This may also be true for the other tables which you are including (`Options`, `Lists`, `Rules`, etc), especially tables which are **one-to-many** which could easily explode the number rows/columns being queried.
A potential way to optimize this is to do the projection yourself as part of the LINQ query.  This would take advantage of a feature of EF Core where it only selects the columns from the database which you have specified.  For example:
**This would select all columns from the product table**
language=cs
var results = _context.Products.ToList();
**This would select only the Id and Name columns from the product table, resulting in less memory usage**
language=cs
var results = _context.Products.Select(x => new ProductDto { 
    Id = x.Id,
    Name = x.Name,
}
From the question I do not know all of the properties on all of the items which you are mapping, so it would be up to you if you wanted to do that mapping manually.  The critical part is that you would need to do that in a call to `Select()` **before** your call to `ToList()` on your query.
**However, there is a potential shortcut if you are using Automapper**
Automapper includes a shortcut which attempts to write these query projections for you. It may not work depending on how much additional logic is happening within Automapper, but it might be worth a try. [You would want to read up on the `ProjectTo<>()` method](https://docs.automapper.org/en/stable/Queryable-Extensions.html).  If you were using projection, the code would probably look something like this:
**Edit: It was correctly pointed out in comments that the Include() calls are not needed when using `ProjectTo<>()`.  Here is a shorter sample with the original included below it**
**Updated:**
language=cs
using AutoMapper.QueryableExtensions;
// ^^^ Added to your usings
// 
    [HttpGet("test")]
    public ActionResult Test()
    {
        var projection = _context.Products.ProjectTo<AbstractProductListItemDto>(_mapper.ConfigurationProvider);
        return Ok(projection.ToList());
    }
**Original:**
language=cs
using AutoMapper.QueryableExtensions;
// ^^^ Added to your usings
// 
    [HttpGet("test")]
    public ActionResult Test()
    {
        var results = _context.Products
            .Include(x => x.Images)
            .Include(x => x.Options)
                .ThenInclude(x => x.Lists)
                    .ThenInclude(x => x.PriceChangeRule)
            .Include(x => x.Options)
                .ThenInclude(x => x.Lists)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.PriceChangeRule)
            .Include(x => x.Options)
                .ThenInclude(x => x.Lists)
                    .ThenInclude(x => x.Items)
                        .ThenInclude(x => x.SupplierFinishingItem)
                            .ThenInclude(x => x.Parent)
            .Include(x => x.Category)
                .ThenInclude(x => x.PriceFormation)
                    .ThenInclude(x => x.Rules)
            .Include(x => x.Supplier)
                .ThenInclude(x => x.PriceFormation)
                    .ThenInclude(x => x.Rules)
            .Include(x => x.PriceFormation)
                .ThenInclude(x => x.Rules)
                .AsNoTracking(); // Removed call to ToList() to keep it as IQueryable<>
        var projection = results.ProjectTo<AbstractProductListItemDto>(_mapper.ConfigurationProvider);
        return Ok(projection.ToList());
    }
