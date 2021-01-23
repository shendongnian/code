    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
                    .Property(i => i.Amount)
                    .HasColumnType("money");
    }
