    modelBuilder
      .Entity<MyEntity>()
      .ToTable("MyTable", "mySchema")
      .HasKey(e => e.Id)
      .Property(e => e.Id)
      .HasColumnName("MyPrimaryKey")                
    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
