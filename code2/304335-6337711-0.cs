    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Photo>()
                .HasMany<Gallery>(x => x.Galleries)
                .WithMany(x => x.Photos)
                .Map(x =>
                {
                    x.MapLeftKey("ID");
                    x.MapRightKey("ID");
                    x.ToTable("GalleryPhotos");
                });
    }
