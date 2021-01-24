    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        private ObservableCollection<Osrs> _tempList;
        public ObservableCollection<Osrs> Osrss { get; set; } = new ObservableCollection<Osrs>();
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            var osrss = await ApiWrapper.GETOsrs();
            foreach (var item in osrss.Values)
            {
                Osrss.Add(item);
            }
            _tempList = Osrss; 
        }
    
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txt = (sender as TextBox).Text;
            var list = _tempList.Where(p => p.Name.Contains(txt, StringComparison.CurrentCultureIgnoreCase)).ToList();
            MylistView.ItemsSource = list;
    
        }
    }
