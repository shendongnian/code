    public class MainDB : DbContext
    {
        public MainDB() : base ("name=DefaultConnection")
        { 
        }
        public DbSet<User> Users { get; set;}
    }
