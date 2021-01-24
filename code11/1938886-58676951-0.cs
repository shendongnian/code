public class ApplicationUser : IdentityUser{
   
   public string FullName { get; set;}
}
When will you apply the migrations to your database you'll see that there will be an extra column which is **FullName**.
You **shouldn't** recreate the properties which are already stored in your existing AspNetUsers table.(Ex: Id, Email, Username etc..) Because this will **not** regenerate your whole table but just adds the new columns to the AspNetUsers table.
But there is **another** approach, and this part is important I think.
Lets assume that you have a ```Product.cs``` : 
public class Product {
   public int Id { get; set;}
   public string ProductNo { get; set; } 
   public string ProductName { get; set;}
}
and you **have already** using a ```DbContext``` to apply your migrations about your Product Model.
Possible ```DbContext.cs``` would be : 
public class DataContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer(@"Server=YourServer; Database=DbName; integrated security=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         //This can be used.  
    }
    
    public DbSet<Product> Products { get; set; }
}
And in general, your ```DataContext``` for your ```ApplicationUser``` would be like this:
public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser>
{
   public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options){}
}
This is a simple way of creating Data Contexts. But when you would like to define a relationship with those 2 tables(Products and AspNetUsers), It can be a relation where all the **users** have his/her own ```Product```, then high possibility you'll get an error or you wont be able to control 2 different DataContexts.
So, for avoiding these kind of struggles, using only **1** Data Context would be a better solution and it should look like this:
public class DataContext: IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
       
        public DbSet<Product> Products { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         
            base.OnModelCreating(modelBuilder);
        }
}
 Now you can simply define **ForeignKeys** between your ```ApplicationUser``` and ```Product```.
For example:
public class ApplicationUser: IdentityUser{
    public string FullName { get; set; }
    public int? ProductId { get; set; }
    public Product Product { get; set; }
}
