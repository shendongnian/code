    public ObservableCollection<IMovie> Movies { get; set; } = new ObservableCollection<IMovie>();
    
    private IMovie _selectedMovie
    public IMovie SelectedMovie
    {
       get => _selectedMovie;
       set
       {
          _selectedMovie = value;
          RaisePropertyChanged(nameof(SelectedMovie));
       }
    }
