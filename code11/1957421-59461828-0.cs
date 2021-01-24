    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<AspNetUserLogins>(o =>
        {
            o.HasNoKey();
        });
    }
