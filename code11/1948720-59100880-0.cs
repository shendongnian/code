    public class YourDbContext :IdentityDbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options)
            : base(options)
        {
        }  
    }
