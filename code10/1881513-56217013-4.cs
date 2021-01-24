    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Things = new ObservableCollection<Thing>
            {
                new Thing("One World Trade Center", 40.712903, -74.013203, SelectMe),
                new Thing("Carlton Centre", -26.205556, 28.046667, SelectMe),
                new Thing("Q1", -28.006111, 153.429444, SelectMe),
                new Thing("Gran Torre Santiago", -33.416944, -70.606667, SelectMe),
                new Thing("Burj Khalifa", 25.197139, 55.274111, SelectMe),
                new Thing("Lakhta Center", 59.987139, 30.177028, SelectMe),
                new Thing("Long Duration Balloon Payload Preparation Buildings", -77.846323, 166.668235, SelectMe),
            };
        }
    
        public ObservableCollection<Thing> Things { get; }
    
    
        private Thing previousThing;
        private void SelectMe(Thing thing)
        {
            if (previousThing != null) previousThing.IsVisibility = false;
            thing.IsVisibility = true;
            previousThing = thing;
        }
    }
    
    public class Thing : BaseViewModel
    {
        private bool _isVisibility;
    
        public Thing(string name, double latitude, double longitude, Action<Thing> selector)
        {
            Name = name;
            Location = new Geopoint(new BasicGeoposition { Latitude = latitude, Longitude = longitude });
            SelectMeCommand = new RelayCommand(() => selector(this));
        }
    
        public string Name { get; set; }
        public Geopoint Location { get; set; }
        public ICommand SelectMeCommand { get; }
        public bool IsVisibility { get => _isVisibility; set => SetProperty(ref _isVisibility, value); }
    }
    public class VisibleWhenNotNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value == true ? Visibility.Visible : Visibility.Collapsed;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotSupportedException();
        }
    }
