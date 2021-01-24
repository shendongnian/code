    SaveMovie(Movie movie)
    {
        var existingGenres = GetGenresFromDatabase();
        var movieGenres = GetGenresFromListBox();
        foreach (var genre in movieGenres)
        {
            if (genre in existingGenres)
            {
                existingGenre = existingGenres.Where(genreId = genre.Id);
                movie.Genres.Add(existingGenre)
            }
            else 
            {
                movies.Add(genre)
            }
        }
        
        dbcontext.Add(movie);
        dbcontext.SaveChanges();
    }
