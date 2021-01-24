    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        public List<Item> Items { get; set; }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
    
            Items = new List<Item>();
            Items.Add(new Item { Name = "Nice Day", IsFav = true });
            Items.Add(new Item { Name = "Nice Day", IsFav = false });
            Items.Add(new Item { Name = "Nice Day", IsFav = false });
        }
    
        private void AddToFevBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var item = btn.DataContext as Item;
            item.IsFav = !item.IsFav;
        }
    }
    public class Item : INotifyPropertyChanged
    {
        public bool IsFav
        {
            get
            {
                return isFav;
    
            }
            set
            {
                isFav = value;
                OnPropertyChanged();
            }
        }
        private bool isFav;
    
        public string Name { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Raise the PropertyChanged event, passing the name of the property whose value has changed.
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
           
        }
    }
    
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (Boolean.Parse(value.ToString()))
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
            {
                return new SolidColorBrush(Colors.Black);
            }
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
