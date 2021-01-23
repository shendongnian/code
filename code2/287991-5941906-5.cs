    public class Movie
    {
         public int MovieId { get; set; }
         public string Name { get; set; }
         public List<Showing> Showings { get; set; }
    }
    public class Showing
    {
         public DateTime StartTime { get; set; }
         public List<Seat> UnsoldSeats { get; set; }
         // Etc
    }
