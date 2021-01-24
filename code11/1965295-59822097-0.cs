    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(500);
            
            entity.Property(e => e.ModifiedBy)
            .IsRequired();
        }
    }
