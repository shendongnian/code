    modelBuilder.Entity<Agent>()
        .HasMany(e => e.ListingRealEstateTransactions)
        .WithOne(e => e.ListingAgent)
        .OnDelete(DeleteBehavior.Restrict);
    
    modelBuilder.Entity<Agent>()
        .HasMany(e => e.SellingRealEstateTransactions)
        .WithOne(e => e.SellingAgent)
        .OnDelete(DeleteBehavior.Restrict);
