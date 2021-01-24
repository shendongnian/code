        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public string SchemaName { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }
        public ApplicationDbContext(string schemaname)
            : base()
        {
            SchemaName = schemaname;
        }
        public DbSet<EmployeeDetail> EmployeeDetail { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var serviceProvider = new ServiceCollection().AddEntityFrameworkSqlServer()
                                .AddSingleton<IModelCustomizer, SchemaContextCustomize>()
                                .BuildServiceProvider();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:SchemaDBConnection"]).UseInternalServiceProvider(serviceProvider);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.MapProduct(SchemaName);
            modelBuilder.RemovePluralizingTableNameConvention();
            if (!string.IsNullOrEmpty(SchemaName))
            {
                modelBuilder.HasDefaultSchema(SchemaName);
            }
            base.OnModelCreating(modelBuilder);
        }
        public string CacheKey
        {
            get { return SchemaName; }
        }
    }
