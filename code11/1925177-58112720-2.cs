        private readonly ObservableCollection<Country> countries;
        private ContinentViewModel selectedContinent;
        private static string selectedCountry;
        private int selectedRadioGroup;
        private ObservableCollection<ContinentViewModel> continents;
        private ListCollectionView countryView;
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _All;
        private bool _Africa;
        private bool _America;
        public bool All
        {
            get
            {
                return _All;
            }
            set
            {
                _All = value;
                CountryView.Refresh();
                SelectedCountry = _All ? countries.FirstOrDefault().DisplayName : SelectedCountry;
                OnPropertyChanged("All");
            }
        }
        public bool Africa
        {
            get
            {
                return _Africa;
            }
            set
            {
                _Africa = value;
                CountryView.Refresh();
                SelectedCountry = _Africa ? countries.Where(_ => _.Continent == Continent.Africa).FirstOrDefault().DisplayName : SelectedCountry;
                OnPropertyChanged("Africa");
            }
        }
        public bool America
        {
            get
            {
                return _America;
            }
            set
            {
                _America = value;
                CountryView.Refresh();
                SelectedCountry = _America ? countries.Where(_ => _.Continent == Continent.America).FirstOrDefault().DisplayName : SelectedCountry;
                OnPropertyChanged("America");
            }
        }
        public MySettings()
        {
            countries = new ObservableCollection<Country>(
                new[]
                {
                new Country() { Continent = Continent.Africa, DisplayName = "Algeria" },
                new Country() { Continent = Continent.Africa, DisplayName = "Egypt" },
                new Country() { Continent = Continent.Africa, DisplayName = "Chad" },
                new Country() { Continent = Continent.Africa, DisplayName = "Ghana" },
                new Country() { Continent = Continent.America, DisplayName = "Canada" },
                new Country() { Continent = Continent.America, DisplayName = "Greenland" },
                new Country() { Continent = Continent.America, DisplayName = "Haiti" }
                });
            CountryView = (ListCollectionView)CollectionViewSource.GetDefaultView(countries);
            CountryView.Filter += CountryFilter;
            Continents = new ObservableCollection<ContinentViewModel>(Enum.GetValues(typeof(Continent)).Cast<Continent>().Select(c => new ContinentViewModel { Model = c }));
        }
        private bool CountryFilter(object obj)
        {
            var country = obj as Country;
            if (country == null) return false;
            if (All && !Africa && !America) return true;
            else if (!All && Africa && !America) return country.Continent == Continent.Africa;
            else if (!All && !Africa && America) return country.Continent == Continent.America;
            return true;
        }
        public ObservableCollection<ContinentViewModel> Continents
        {
            get { return continents; }
            set
            {
                continents = value;
                OnPropertyChanged("Continents");
            }
        }
        public ListCollectionView CountryView
        {
            get { return countryView; }
            set
            {
                countryView = value;
                OnPropertyChanged("CountryView");
            }
        }
        public class Country
        {
            public string DisplayName { get; set; }
            public Continent Continent { get; set; }
        }
        public enum Continent
        {
            All,
            Africa,
            America
        }
        public class ContinentViewModel
        {
            public Continent Model { get; set; }
            public string DisplayName
            {
                get
                {
                    return Enum.GetName(typeof(Continent), Model);
                }
            }
        }
        public ContinentViewModel SelectedContinent
        {
            get { return selectedContinent; }
            set
            {
                selectedContinent = value;
                OnContinentChanged();
                this.OnPropertyChanged("SelectedContinent");
            }
        }
        private void OnContinentChanged()
        {
            CountryView.Refresh();
        }
        public int SelectedRadioGroup
        {
            get { return selectedRadioGroup; }
            set
            {
                selectedRadioGroup = value;
                OnPropertyChanged("SelectedRadioGroup");
            }
        }
        public string SelectedCountry
        {
            get { return selectedCountry; }
            set
            {
                if (selectedCountry == value) return;
                selectedCountry = value;
                OnPropertyChanged("SelectedCountry");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
