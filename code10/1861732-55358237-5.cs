    public class BlogContext : IdentityDbContext<User>
        {
            public BlogContext(DbContextOptions options) : base()
            {
    
            }
            public DbSet<User> Users { get; set; }
        }
    public class User:IdentityUser
        {
        }
