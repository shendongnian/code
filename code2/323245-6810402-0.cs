    [DependsOn("MovieList")]
    public bool HasMovies
    {
        get { return MovieList != null && MovieList.Count > 0; }
    }
    public ObservableCollection<Movie> MovieList
    {
        get;
        private set;
    }
