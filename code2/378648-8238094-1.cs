    public class Artist 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; } // You forgot this
        public Genre Genre { get; set; }
    }
