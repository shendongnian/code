cs
public class WareHouse
{
  [Key]
  public int Id { get;set; }
  public string Name {get;set;}
  public ICollection<Container> Containers {get;set;}
}
public abstract class Container
{
  [Key]
  public int Id {set;set;}
  public int WareHouseId {get;set;}
  [ForeignKey(nameof(WareHouseId))]
  public WareHouse WareHouse {get;set;}
  public string Name {get;set;}
  public ICollection<Product> Products {get;set;}
}
public class Box : Container
{
  // box specific stuff here
}
public class Chest : Container
{
  // chest specific stuff here
}
public class Product
{
  [Key]
  public int Id {set;set;}
  public int ContainerId {get;set;}
  [ForeignKey(nameof(ContainerId))]
  public Container Container {get;set;}  
}
And your context something like this:
csharp
public class MyContext : DbContext
{
  public virtual DbSet<WareHouse> WareHouses {get;set;}
  public virtual DbSet<Container> Containers {get;set;}
  public virtual DbSet<Product> Products {get;set;}
  protected override void OnModelCreating(ModelBuilder builder)
  {
    // puts the class name in a column, makes it human readable
    builder.Entity<Container>().Hasdiscriminator<string>("Type");
    // i don't think you need to do this, but if it doesn't work try this
    // builder.Entity<Box>().HasBaseType(typeof(Container));
    // builder.Entity<Chest>().HasBaseType(typeof(Container));
  }
}
Then you can get all the products from the warehouse with id=1 like this:
csharp
int warehouseId = 1;
Product[] allProducts = myContext.WareHouses
  .Where(wh => wh.Id == warehouseId)
  .SelectMany(wh => wh.Container)
  //.OfType<Box>() if you only want products in boxes
  .SelectMany(wh => wh.Products)
  .ToArray();
I know you said in your comment that you tend to use linq's lambda syntax, but I feel I should point out that you are doing a lot of unnecessary joins in your query syntax example. linq to entities will take care of all that for you if you have set things up correctly.
  [1]: https://entityframework.net/tph
