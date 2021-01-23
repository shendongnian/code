    public class Artist {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
    public class Genre {
        public long Id { get; set; }
        public string Title { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
    public class MusicDB : DbContex {
    
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        modelBuilder.Entity<Artist>()
            .HasMany(c => c.Genres)
            .WithMany(x => x.Artists)
            .Map(a => {
                a.ToTable("ArtistsGenres");
                a.MapLeftKey("ArtistId");
                a.MapRightKey("GenreId");
            });
            
    }
