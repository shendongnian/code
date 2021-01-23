        public class Genre
        {
           public int GenreID { get; set;}
           public string Name { get; set; }
        }
        
        public class Movie
        {
           public int MovieID { get; set; }
           public string Title { get; set; }
        
           public ICollection<Genre> Genres { get; set; }
        }
    ....
    
        //Movie
       var movieCfg = modelBuilder.Entity<Movie>();
       movieCfg.ToTable("Movie", "Media");
       movieCfg.HasMany(m => m.Genres)
               .WithMany()
               .Map(m =>
               {
                  m.MapLeftKey("MovieID");
                  m.MapRightKey("GenreID");
                  m.ToTable("MovieGenre", "Media");
               });
