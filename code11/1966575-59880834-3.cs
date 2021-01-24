    public List<City> Cities { get; } = new List<City>();
    
    public List<Person> Persons { get; } = new List<Person>();
    
    public ObservableCollection<Person> ShownPeople { get; } = new ObservableCollection<Person>();
    public ICommand SelectedCitiesChangedCommand { get; }
    
    public ViewModel()
    {
        SelectedCitiesChangedCommand = new DelegateCommand(SelectedCitiesChanged);
    }
    private void SelectedCitiesChanged()
    {
        var checkedCities = Cities.Where(city => city.IsChecked);
                
        ShownPeople.Clear();
        ShownPeople.AddRange(Persons.Where(person => checkedCities.Any(city => city.CityName == person.City)));
    }
