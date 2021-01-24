     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Memy>()
                .Property(p => p.Id_mema)
                .ValueGeneratedOnAdd();
        }
