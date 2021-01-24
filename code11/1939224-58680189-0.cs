    public static class MoviesRentCart
    {
            public static List<Movie> movieRentList;
    
            public static void addCartList(string title, string date, int duration, double price, string type)
            {
                Movie newMovie = new Movie(title, date, duration, price, type);
    
                movieRentList.Add(newMovie);
             }
    }
