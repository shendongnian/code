    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _hostingEnvironment;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IConfiguration configuration
            , IHostingEnvironment hostingEnvironment)
            : base(options)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        public DbSet<Product> Products { get; set; }
        public override int SaveChanges()
        {            
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.Entity is Product product && product.UserImage == null)
                {
                    product.UserImage = _hostingEnvironment.ContentRootPath + new Random().Next(10).ToString();
                }
            }
            return base.SaveChanges();
        }
    }
