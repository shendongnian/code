    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
    }
    public class Customer {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class MyDbContext : DbContext {
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public MyDbContext() { }
        protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Add<TableNameUppercaseConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
    public class TableNameUppercaseConvention : IConfigurationConvention<Type, EntityTypeConfiguration> {
        public void Apply(Type typeInfo, Func<EntityTypeConfiguration> configuration) {
            configuration().ToTable(typeInfo.Name.ToUpper());
        }
    }
