    //added
    protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
    
            builder.Entity<PersonModel>(table =>
            {
                table.OwnsOne(
                    x => x.ContentModel,
                    content =>
                    {
                        content.Property(x => x.Name).HasColumnName("Name");
                        content.Property(x => x.Visits).HasColumnName("Visits");
                        content.Property(x => x.Date).HasColumnName("Date");
                    });
            });
        }
