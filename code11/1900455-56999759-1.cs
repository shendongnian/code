    modelBuilder.Entity<Agreement>()
        .HasOne(x => x.ByerAgreementInfo)
        .WithOne()
        .HasForeignKey<Agreement>(p => new {p.AgreementIdForBuyer, p.AgreementIdForBuyer})
        .OnDelete(DeleteBehavior.Restrict); // <-- Here it is
    
    modelBuilder.Entity<Agreement>()
        .HasOne(x => x.SellerAgreementInfo)
        .WithOne()
        .HasForeignKey<Agreement>(p => new {p.AgreementIdForSeller, p.OwnerActorIdForSeller})
        .OnDelete(DeleteBehavior.Restrict); // <-- Here it is
