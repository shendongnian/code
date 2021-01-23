        public class MainViewModel
        {
            private ObservableCollection<ContinentViewModel> _continents;
            
            public ObservableCollection<ContinentViewModel> Continents
            {
                get { return _continents; }
                set
                {
                _continents = value;
                ContinentView = new ListCollectionView(_continents);
                ContinentView.CurrentChanged += (sender, agrs) => CurrentContinent = ContinentView.CurrentItem as ContinentViewModel;
            }
        }
        public ListCollectionView ContinentView {get; private set;}
    
        /// <summary>
        /// Use this to determine the current item in the list 
        /// if not willing to use \ notation in the binding.
        /// </summary>
        public ContinentViewModel CurrentContinent { get; set; }
    }
    public class ContinentViewModel
    {
        private Continent _model;
    
        public Continent Model
        {
            get { return _model; }
            set
            {
                _model = value;
                Countries = _model.Countries
                    .Select(p => new CountryViewModel { Model = p })
                    .ToList();
            }
        }
    
        public string Name
        {
            get { return Model.Name; }
        }
    
        public int Area
        {
            get { return Model.Area; }
        }
    
        public List<CountryViewModel> Countries { get; private set; }
    }
    public class CountryViewModel
    {
        public Country Model { get; set; }
    
        public string Name
        {
            get { return Model.Name; }
        }
    
        public int Population 
        {
            get { return Model.Population; }
        }
    }
