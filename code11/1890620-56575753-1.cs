    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Items> MyClasses { get; set; } = new ObservableCollection<Items>();
    
        private ICollectionView _groupView;
        public ICollectionView GroupView
        {
            get
            {
                return _groupView;
            }
            set
            {
                Set(ref _groupView, value);
            }
        }
    
        public MainPage()
        {
            this.InitializeComponent();
    
            MyClasses.Add(new Items { Name = "Nico", Complete = false });
            MyClasses.Add(new Items { Name = "LIU", Complete = true });
            MyClasses.Add(new Items { Name = "He", Complete = true });
            MyClasses.Add(new Items { Name = "Wei", Complete = false });
            MyClasses.Add(new Items { Name = "Dong", Complete = true });
            MyClasses.Add(new Items { Name = "Ming", Complete = false });
    
        }
    
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var groups = from c in MyClasses
                         group c by c.Complete;
    
            var cvs = new CollectionViewSource();
            cvs.Source = groups;
            cvs.IsSourceGrouped = true;
    
            var datagrid = sender as DataGrid;
            GroupView = cvs.View;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }
    
            storage = value;
            OnPropertyChanged(propertyName);
        }
    
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
