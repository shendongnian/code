    // Can't use this in our EnterpriseDbContext because IdentityUser will require ref. to .Identity.EntityFramework
    public class EnterpriseUser : IdentityUser<Guid>
    {
       // Stuff.
    }
    
    // Use this instead in our EnterpriseDbContext to map to the same table
    [Table("EnterpriseUsers")]
    public class User
    {
       public Guid Id { get; set; }
       public string UserName { get; set; }
       // Stuff...
    }
