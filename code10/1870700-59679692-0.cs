     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Todo>(entity =>
                {
            entity.Property(x => x.Id)
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .ValueGeneratedOnAdd()
                        **.UseIdentityColumn();**
        }
