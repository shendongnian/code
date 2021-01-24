public class ProductCategory
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
public class Product
{
    ...
    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
}
public class Category
{
    ...
    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
}
// DbContext
public DbSet<ProductCategory> ProductCategories { get; set; }
public override OnModelCreating(ModelBuilder builder)
{
    builder.Entity<ProductCategory>()
           .HasOne(pc => pc.Product)
           .WithMany(p => p.ProductCategories);
    builder.Entity<ProductCategory>()
           .HasOne(pc => pc.Category)
           .WithMany(c => c.ProductCategories);
}
// Query
var result = await dbContext.ProductCategories
                     .Select(pc => new {
                         ProductName = pc.Product.Name, 
                         ProductCode = pc.Product.Code, 
                         CategoryName = pc.Category.Name 
                      })
                     .SingleOrDefaultAsync(pc => pc.Id == idToFind)
