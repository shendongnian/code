    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProduct>()
                .HasKey(up => new { up.ProductId, up.ApplicationUserId });
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.Product)
                .WithMany(p => p.UserProducts)
                .HasForeignKey(up => up.ProductId);
            modelBuilder.Entity<UserProduct>()
                .HasOne(up => up.ApplicationUser)
                .WithMany(au => au.UserProducts)
                .HasForeignKey(up => up.ApplicationUserId);
        }
