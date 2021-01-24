    <Window 
        DataContext={Binding MyViewModel, Source={StaticResource Locator}}
        >
        <ListBox x:Name="moviesListBox" ItemsSource="{Binding Movies}" SelectedItem="{Binding SelectedMovie, Mode=TwoWay}" />
        <ListBox x:Name="actorsListBox" ItemsSource="{Binding SelectedMovie.Actors}" SelectedItem="{Binding SelectedActor, Mode=TwoWay}" /> 
    </Window>
    public MovieViewModel : ViewModelBase
    {
        public ObservableCollection<IMovie> Movies { get; } = new ObservableCollection<IMovie>();
        public MovieViewModel()
        {
            foreach (var movie in blc.GetAllMovies())
                Movies.Add(movie);
        }
        private Movie _selectedMovie;
        public Movie SelectedMovie
        {
            get
            {
                return _selectedValue;
            }
            set
            {
                Set(ref _selectedValue, value);
            }
        }
    }
    public class ViewModelLocator
    {
        // Constructor to register ViewModels, etc...
        //
        public MovieViewModel MyViewModel => /* resolve the view model */
    }
