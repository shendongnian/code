    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasMany(p => p.Friends)
            .WithOptional()
            .Map(conf => conf.MapKey("FriendID"));
        modelBuilder.Entity<Person>()
            .HasOptional(p => p.Parent)
            .WithMany()
            .Map(conf => conf.MapKey("ParentID"));
    }
