    public sealed partial class Cars : Page, INotifyPropertyChanged
    {
        public object _ItemSource { get; set; }
        public object ItemSource
        {
            get { return _ItemSource; }
            set
            {
                _ItemSource = value;
                this.OnPropertyChanged();
            }
        }
        public DataTemplate _itemTemplate { get; set; }
        public DataTemplate ItemTemplate
        {
            get { return _itemTemplate; }
            set
            {
                _itemTemplate = value;
                this.OnPropertyChanged();
            }
        }
        public Cars()
        {
            this.InitializeComponent();
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void CarsClick(object sender, RoutedEventArgs e)
        {
            ItemSource = new List<Car>() { new Car() { carprop1 = "1", carprop2 = "2" } };
            ItemTemplate = this.Resources["CarKey"] as DataTemplate;
        }
        private void BikeClick(object sender, RoutedEventArgs e)
        {
            ItemSource = new List<Bike>() { new Bike() { Bikeprop1 = "1", Bikeprop2 = "2" } };
            ItemTemplate = this.Resources["BikeKey"] as DataTemplate;
        }
    }
    public class Car
    {
        public string carprop1 { get; set; }
        public string carprop2 { get; set; }
    }
    public class Bike
    {
        public string Bikeprop1 { get; set; }
        public string Bikeprop2 { get; set; }
    }
