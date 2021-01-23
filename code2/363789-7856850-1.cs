    // get all movies for a particular genre
    var movies = movieContext.Movies.Where(m => m.Genres.Any(g => g.GenreID = id))
                                    .OrderBy(m => m.Name)
                                    .ToList();
    // get all movies 
    var movies = movieContext.Movies.OrderBy(m => m.Name).Take(10).ToList();
