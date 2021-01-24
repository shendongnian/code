    modelBuilder.Entity<Celebrity>()
        .Property(e => e.OtherNames)
        .HasConversion(
            value => JsonConvert.SerializeObject(value),
            dbValue => JsonConvert.DeserializeObject<List<string>>(dbValue));
