    // get genres for the applicable movies
    var genres = context.Movies
        .Where(x => x.ReleaseDate >= startDate && x.ReleaseDate <= endDate)
        .SelectMany(x => x.Genres)
        .Distinct(new GenreEqualityComparer())
        .Select(x => new GenreViewModel{ GenreId = x.GenreId, Name = x.Name})
        .ToList();
    // Get the movies with their Genre IDs.
    var movies = context.Movies
        .Where(x => x.ReleaseDate >= startDate && x.ReleaseDate <= endDate)
        .Select(x => new MovieViewModel
        {
            MovieId = x.MovieId,
            Name = x.Name,
            GenreIds = x.Genres.Select(g => g.GenreId).ToList()
        }).ToList();
