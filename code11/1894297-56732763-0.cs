    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Record>(entity =>
       {
           entity.HasIndex(e => e.Client)
            .HasName("Record_Filtered_Index")
            .HasFilter("([IsActive]=(1))");
       });
    }
