    <Window 
        DataContext={Binding MyViewModel, Source={StaticResource Locator}}
        >
        <ListBox x:Name="moviesListBox" ItemsSource="{Binding Movies}" SelectedItem="{Binding SelectedMovie, Mode=TwoWay}" />
        <ListBox x:Name="actorsListBox" ItemsSource="{Binding SelectedMovie.Actors}" SelectedItem="{Binding SelectedActor, Mode=TwoWay}" /> 
    </Window>
    public MyViewModel: ViewModelBase
    {
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
