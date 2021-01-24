    MovieViewModel[] movies = db.MoviesData.Select(movie => new MovieViewModel
    {
        MovieID = movie.MovieID,
        MovieName = movie.MovieName,
        MovieDescription = movie.MovieDescription,
        MoviePrice = movie.MoviePrice,
        MovieCategory = movie.MovieCategory,
        MovieYear = movie.MovieYear
    }).ToArray();
