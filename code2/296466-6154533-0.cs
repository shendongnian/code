    public class YourContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddresTypes { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
    
            modelBuilder.Entity<Address>()
                        .HasRequired(a => a.AnAddressType)
                        .WithMany()
                        .WillCascadeOnDelete(false);
    
            modelBuilder.Entity<Address>()
                        .HasRequired(a => a.AnotherAddressType)
                        .WithMany()
                        .WillCascadeOnDelete(false);
        }
    }
