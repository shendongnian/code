    public class MovieTheater
    {
    	public string Id { get; set; }
    	public string Name { get; set; }
    
    	public List<Movie> MoviesOnShow { get; set; }
    }
    
    public class Movie
    {
    	public string Name { get; set; }
    	public DateTime ReleaseDate { get; set; }
    	public int NumOfShows { get; set; }
    }
