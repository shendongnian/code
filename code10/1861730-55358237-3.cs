    public class BlogContext : IdentityDbContext<User>
        {
            public BlogContext(DbContextOptions<DbContext> options) : base()
            {
    
            }
            public DbSet<User> Users { get; set; }
        }
    public class User:IdentityUser
        {
        }
