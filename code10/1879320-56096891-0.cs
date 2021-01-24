    modelBuilder.Entity<UserCategory>()
        .HasOne(s => s.UserDefaults)
        .WithOne(s => s.UserCategory)
        .HasForeignKey<UserDefaults>(s => new { s.UserId, s.CategoryId })
        .IsRequired();
