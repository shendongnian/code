    public class AlbumViewModel
    {
        public string GenreId { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    
        public string ArtistId { get; set; }
        public IEnumerable<Artist> Artists { get; set; }
    
        public Album Album { get; set; }
    }
