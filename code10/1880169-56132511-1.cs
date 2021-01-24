builder.Entity<UserModel>(b =>
{
    // Primary key
    b.HasKey(u => u.Id);
    //map properties
    b.Property(u => u.FirstName ).HasName("FirstName").IsUnique();
    b.Property(u => u.SecondName ).HasName("SecondName");
    // Maps to the AspNetUsers table
    b.ToTable("AspNetUsers");
   
});
builder.Entity<UserModelSplit>(b =>
{
    // Primary key
    b.HasKey(u => u.Id);
     //map properties
    b.Property(u => u.UserName ).HasName("UserName").IsUnique();
    b.Property(u => u.NormalizedUserName ).HasName("NormalizedUserName");
...
...
...
    // Maps to the AspNetUsers table
    b.ToTable("AspNetUsersSplit");
   
});
public class EFDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>  
    {  
        public EFDbContext (DbContextOptions<EFDbContext > options) : base(options)  
        {  
  
        }  
    }  
  [1]: https://www.c-sharpcorner.com/article/asp-net-core-mvc-authentication-and-role-based-authorization-with-asp-net-core/
  [2]: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-2.2
