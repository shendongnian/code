      protected override void OnModelCreating(ModelBuilder builder)
      {
        base.OnModelCreating(builder);
        builder.Entity<Cow>().HasMany(x => x.CowOwners).WithOne(x => x.Cow);
        builder.Entity<Owner>().HasMany(u => u.Cows).WithOne(X => X.Owner); // Cows instead of CowOwners
        builder.Entity("DogFace.API.Entities.OwnerCow", b =>
        {
          b.HasOne("DogFace.API.Entities.Cow", "Cow")
          .WithMany("OwnerCows")
          .HasForeignKey("CowId")
          .OnDelete(DeleteBehavior.Restrict);
         b.HasOne("DogFace.API.Entities.Owner", "Owner")
         .WithMany("CowOwners") // CowOwners instead of OwnerCows
         .HasForeignKey("OwnerId")
         .OnDelete(DeleteBehavior.Restrict);
        });
      }
