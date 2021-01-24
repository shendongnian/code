    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<Data> _dataList = null;
        public ObservableCollection<Data> DataList
        {
            get { return _dataList; }
            set
            {
                _dataList = value;
                OnPropertyChanged("DataList");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataList = new ObservableCollection<Data>
            {
                new Data() { Id = 1, Name = "Dan" },
                new Data() { Id = 2, Name = "Julie" }
            };
            DataContext = this;
        }
    }
