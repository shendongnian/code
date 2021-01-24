    protected void OnModelCreating( DbModelBuilder modelBuilder )
    {
        // configure like an entity but use .ComplexType<>()
        modelBuilder.ComplexType<Address>()
            // e.g. set max size of one of the properties
            .Property( a => a.Postcode )
            .HasMaxLength( 10 );
        // etc.
        // map properties to columns if you don't want to use default naming convention
        modelBuilder.Entity<YourEntityType>()
            .Property( yet => yet.LandlordAddress.Postcode )
            .HasColumnName( "LandlordPostcode" );
        modelBuilder.Entity<YourEntityType>()
            .Property( yet => yet.LandordAgentAddress.Postcode )
            .HasColumnName( "LandlordAgentPostcode" );
    }
