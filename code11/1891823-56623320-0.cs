    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Genre> Genres { get; private set; } = new List<Genre>();
    }
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; private set; } = new List<Movie>();
    }
