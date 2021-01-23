    modelBuilder.Entity<MODEL_OF_TABLE>(entity =>
    {
        entity.Property(e => e.Id).ValueGeneratedNever(); // <= this line must remove
        ...
    }
