    public class MoviesRentCart
    {
            public List<Movie> movieRentList = new List<Movie>();
    
            public void addCartList(string title, string date, int duration, double price, string type)
            {
                Movie newMovie = new Movie(title, date, duration, price, type);
    
                movieRentList.Add(newMovie);
             }
    }
