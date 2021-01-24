    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<AUTHORs>()
         .HasMany<BOOKs>(s => s.BOOKs)
         .WithMany(c => c.AUTHORs)
         .Map(cs =>
         {
              cs.MapLeftKey("Aid");
              cs.MapRightKey("ISBN");
              cs.ToTable("Book_Author"); // Use the correct junction table name here. and correct key names
         });
    }
