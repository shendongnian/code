    modelBuilder.Entity<Artist>()
        .HasMany(c => c.Genres)
        .WithMany(x => x.Artists)
        .Map(a => {
            a.ToTable("ArtistsGenres");
            a.MapLeftKey("ArtistId");
            a.MapRightKey("GenreId");
        });
