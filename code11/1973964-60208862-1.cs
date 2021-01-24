    protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NameOfEntity>()
                        .Property(p => p.NameOfProperty)
                        .HasPrecision(9, 4); // or whatever your schema specifies
        }
