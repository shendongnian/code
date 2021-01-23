    protected override void OnModelCreating(DbModelBuilder mb)
    {
        mb.Entity<User>()
            .HasMany(u => u.Ignores)
            .WithReequired()
            .HasForeignKey(u => u.ID);
    
        mb.Entity<User>()
            .HasMany(u => u.Followers)
            .WithMany(u => u.Following);
            // If you want to specify a table, use the following line:
            // .Map(m => m.ToTable("CustomManyToManyTableName");
    }
