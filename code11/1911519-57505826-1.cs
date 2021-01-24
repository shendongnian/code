    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PolicyMapping>()
                .HasOne(x => x.PolicyA)
                .WithOne()
                .HasForeignKey<PolicyMapping>(p => p.PolicyAId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PolicyMapping>()
                .HasOne(x => x.PolicyB)
                .WithOne()
                .HasForeignKey<PolicyMapping>(p => p.PolicyBId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<PolicyMapping>()
                .HasOne(x => x.Bank)
                .WithOne()
                .HasForeignKey<PolicyMapping>(p => p.BankId)
                .OnDelete(DeleteBehavior.Restrict);
        }
