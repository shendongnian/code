    public class FooDbContext : DbContext
    {
        public string SchemaName { get; set; }
        static FooDbContext()
        {
            Database.SetInitializer<FooDbContext>(null);
        }
        public FooDbContext(string schemaName)
            : base("name=connString1")
        {
            this.SchemaName = schemaName;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new City_Map(this.SchemaName));
            modelBuilder.Configurations.Add(new Customer_Map(this.SchemaName));
            modelBuilder.Configurations.Add(new CustomerSecurity_Map(this.SchemaName));
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
    }
