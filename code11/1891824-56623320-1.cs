    var movies = context.Movies
        .Where(x => x.ReleaseDate >= startDate && x.ReleaseDate <= endDate)
        .Select(x => new MovieViewModel
        {
            MovieId = x.MovieId,
            Name = x.Name,
            Genres = x.Genres.Select(g => new GenreViewModel {GenreId = g.GenreId, Name = g.Name).ToList()
        }).ToList();
