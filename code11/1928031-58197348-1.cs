        public class ApplicationDbContext : IdentityDbContext
        {
            public DbSet<Book> Books { get; set; }
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }
        }
