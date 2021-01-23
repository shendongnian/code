    public IObservable<Movie> FindMovieById(int movieId)
    {
        var url = String.Format(MOVIE_INDIVIDUAL_INFORMATION, ApiKey, movieId);
        var jsonResponse = GetJsonResponse(url);
        return jsonResponse.Select(r => Parser.ParseMovie(r));
    }
    
    private static IObservable<string> GetJsonResponse(string url)
    {
        return Observable.Using(() => new WebClient(),
            client => client.GetDownloadString(url));
    }
