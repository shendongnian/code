    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().Property(p => p.UserId)
        .StoreGeneratedPattern = System.Data.Metadata.Edm.StoreGeneratedPattern.None;
        modelBuilder.Entity<Person>().MapSingleType(p => new
        {
            p.UserId,
            p.Firstname,
            p.SurName,
        })
        .ToTable("Person");
        modelBuilder.Entity<User>().MapSingleType(u => new
        {
            u.UserId,
            u.CreatedOn,
            u.Firstname,
            u.SurName,
        })
        .ToTable("User");
    }
