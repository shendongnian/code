     public class Movie
        {
            public string movieTitle { get; set; }
            public string movieReleaseDate { get; set; }
            public int movieDuration { get; set; }
            public double movieRentalPrice { get; set; }
            public string movieRentType { get; set; }
    
            public MovieRent(string mtitle, string mdate, int mtime, double mprice, string type)
            {
                movieTitle = mtitle;
                movieReleaseDate = mdate;
                movieDuration = mtime;
                movieRentalPrice = mprice;
                movieRentType = type;
            }
        }
    class MoviesRentCart
        {
            public List<Movie> movieRentList;
            public MoviesToRent()
            {
                movieRentList = new List<MovieRent>();
            }
    
            public static MoviesToRent addCartList(string title, string date, int duration, double price, string type)
            {
                //What does this line do here?
                //MoviesToRent movieList = new MoviesToRent();
    
                //fixed missing space
                Movie newMovie = new Movie(title, date, duration, price, type);
    
                movieList.movieRentList.Add(newMovie);
    
                return movieList;
            }
        }
