    modelBuilder.Entity<Event>()
        .HasOne<Client>(e => e.Client)
        .WithMany()
        .IsRequired()
        .OnDelete(DeleteBehavior.Cascade);
