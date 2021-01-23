    private Movie selectedMovie;
    
    public Movie SelectedMovie
    {
        get
        {
            return selectedMovie;
        }
        set
        {
            selectedMovie = value;
            InvokePropertyChanged("SelectedMovie");
        }
    }
