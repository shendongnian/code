    public IEnumerable<Game> GetGames(string? genre, string? subGenre)
    {
        return Games.Where(x => (String.IsNullOrEmpty(genre) || x.SubGenre.Genre.GenreName == genre) 
                       && (String.IsNullOrEmpty(subGenre) || x.SubGenre.SubGenreName == subGenre));
    }
