    modelBuilder.Entity<User>()
         .HasOne<Suburb>(s => s.Suburb)
         .WithMany(u => u.Users)
         .HasForeignKey(u => u.SuburbId)
         .IsRequired(false);
         .OnDelete(DeleteBehavior.Restrict); // <-- Here it is
