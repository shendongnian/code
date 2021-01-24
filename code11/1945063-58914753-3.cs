    modelBuilder.Entity<AddressDto>()
        .HasMany(c => c.CountryLocaleDto)
        .WithOne(a => a.AddressDto);
        .HasForeignKey(a => a.CountryId);
        .HasPrincipalKey(c => c.Id);
            
