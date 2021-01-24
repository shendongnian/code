    modelBuilder
      .Entity<MyEntity>()
      .ToTable("DatabaseTable", "DatabaseSchema")
      .HasKey(e => e.Id)
      .Property(e => e.Id)
      .HasColumnName("DatabasePrimaryKey")                
    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
