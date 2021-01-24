    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.ReplaceService<IModelCacheKeyFactory, SchemaModelCacheKeyFactory>();
            });
        }
    }
    public class DatabaseOptions
    {
        public string Schema { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public string Schema { get; }
        public ApplicationDbContext(DbContextOptions options, IOptions<DatabaseOptions> databaseOptions)
            : base(options)
        {
            Schema = databaseOptions.Value.Schema;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MY_VIEW>().ToTable($"{Schema}.MYVIEW");
        }
    }
    public class SchemaModelCacheKeyFactory : ModelCacheKeyFactory
    {
        public SchemaModelCacheKeyFactory(ModelCacheKeyFactoryDependencies dependencies)
            : base(dependencies)
        {
        }
        public override object Create(DbContext context)
        {
            if (context is ApplicationDbContext applicationDbContext)
            {
                return new SchemaModelCacheKey(context, applicationDbContext.Schema);
            }
            else
            {
                return base.Create(context);
            }
        }
    }
    public class SchemaModelCacheKey : ModelCacheKey
    {
        public SchemaModelCacheKey(DbContext context, string schema) : base(context)
        {
            _schema = schema;
        }
        private readonly string _schema;
        protected virtual bool Equals(SchemaModelCacheKey other) => _schema == other._schema && base.Equals(other);
        public override bool Equals(object obj) => (obj is SchemaModelCacheKey otherAsKey) && Equals(otherAsKey);
        public override int GetHashCode() => base.GetHashCode() + _schema.GetHashCode();
    }
