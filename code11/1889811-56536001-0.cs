public class IdentityContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) 
    { }
    
    // ...
}
So it complains if you invokes `base(options)` within the derived context:
public partial class MyDbContext : IdentityContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    { }
}
### How to Solve
Change the constructor of your `IdentityContext` to receive a **`DbContextOptions options`** and make the constructor of `MyDbContext` to accept a **`DbContextOptions<MyDbContext> options`**:
public class IdentityContext : IdentityDbContext&lt;ApplicationUser, ApplicationRole, int&gt;
{
    public IdentityContext(<b>DbContextOptions options</b>) : base(options)
    {
    }
}
public partial class MyDbContext : IdentityContext
{
    public MyDbContext(<b>DbContextOptions&lt;MyDbContext&gt; options</b>) : base(options)
    { }
}
----------
As a side note, you're adding identity services with role as `ApplicationBlogRole` instead of `ApplicationRole`:
    services.AddIdentity<ApplicationUser, ApplicationBlogRole>()  // it might cause problems in future.
Maybe it should be :
    services.AddIdentity<ApplicationUser, ApplicationRole>() 
