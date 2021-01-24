     protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity>()
                .HasKey(n => n.ID);
            modelBuilder.Entity<Contract>()
               .HasKey(n => new { n.Entity1ID, n.Entity2ID });
            modelBuilder.Entity<Contract>()
                .HasOne(n => n.Entity1)
                .WithMany(n => n.Contracts1)
                .HasForeignKey(n => n.Entity1ID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Contract>()
                .HasOne(n => n.Entity2)
                .WithMany(n => n.Contracts2)
                .HasForeignKey(n => n.Entity2ID)
                .OnDelete(DeleteBehavior.Restrict);
        }
