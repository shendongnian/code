    protected override void OnModelCreating(ModelBuilder builder)
    {
         base.OnModelCreating(builder);
         //...
         modelBuilder.Entity<AspNetUserLogins>()
                .HasKey(c => new { c.LoginProvider , c.ProviderKey });
    }
    
