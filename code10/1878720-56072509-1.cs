      protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EntityClass>()
                .Property(p => p.Amount )
                .HasColumnType("decimal(28,20)");
