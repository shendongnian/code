    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
    }
    public class Album
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
