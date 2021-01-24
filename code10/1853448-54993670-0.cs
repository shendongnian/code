    public class BloggingContext : DbContext
    {
        private DbConnection _connection;
    
        public BloggingContext(DbConnection connection)
        {
          _connection = connection;
        }
    
        public DbSet<Blog> Blogs { get; set; }
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
    }
