        // First client/job relationship
        modelBuilder.Entity<Client>()
            .HasMany(t => t.Jobs)
            .WithOne(g => g.Client)
            .HasForeignKey(g => g.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
        // Second client/job relationship (warranty)
        modelBuilder.Entity<Client>()
            .HasMany(a => a.WarrantyCompanyJobs)
            .WithOne(b => b.WarrantyCompany)
            .HasForeignKey(b => b.WarrantyCompanyId);
