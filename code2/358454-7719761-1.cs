    public class ManyOneToManyContext : DbContext {
        static ManyOneToManyContext() {
            Database.SetInitializer<ManyOneToManyContext>(new ManyOneToManyInitializer());
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StoreLocation> StoreLocations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
            modelBuilder.Entity<Customer>().HasMany(c => c.Addresses).WithOptional(a => a.Customer).HasForeignKey(a => a.CustomerId);
            modelBuilder.Entity<StoreLocation>().HasRequired(s => s.Address).WithOptional(a => a.StoreLocation).Map(t => t.MapKey("AddressId"));
            modelBuilder.Entity<Employee>().HasMany(e => e.Addresses).WithOptional(a => a.Employee).HasForeignKey(e => e.EmployeeId);
        }
    }
