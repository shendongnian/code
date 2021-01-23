    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<A>()
            .HasMany(a => a.ObjectsOfB)
            .WithMany(b => b.OtherObjectsOfA)
            .Map(x =>
            {
                x.MapLeftKey("AId");
                x.MapRightKey("BId");
                x.ToTable("ABs");
            });
        modelBuilder.Entity<B>()
            .HasRequired(b => b.ObjectA)  // or HasOptional
            .WithMany()
            .WillCascadeOnDelete(false);  // not sure if necessary, you can try it
                                          // without if you want cascading delete
    }
