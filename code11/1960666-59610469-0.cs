    modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
