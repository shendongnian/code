    public class Movie
    {
        public Movie()
        {
            Genre = "Action";        
        }
        public int ID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
       
    }
    public class MovieViewModel
    {
       
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
       
    }
