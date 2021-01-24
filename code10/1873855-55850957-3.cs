    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<CustomerAddress>()
           .HasKey(c => new { c.CustomerId, c.AddressId});
    
       modelBuilder.Entity<Customer>()
           .HasMany(c => c.CustomerAddresses)
           .WithRequired()
           .HasForeignKey(c => c.CustomerId);
    
       modelBuilder.Entity<Address>()
           .HasMany(c => c.CustomerAddresses)
           .WithRequired()
           .HasForeignKey(c => c.AddressId);  
    }
