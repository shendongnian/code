    public class Movie
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public int ReleasedYear { get; set; }
        public double Price { get; set; }
        public Movie ChangePrice( double multiplier )
        {
            return new Movie()
                   {
                       Name = Name,
                       Genre = Genre,
                       ReleasedYear = ReleasedYear,
                       Price = Price * multiplier
                   };
        }
    }
