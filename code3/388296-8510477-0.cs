    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<Tuple<DateTime, DateTime>> _dates = new ObservableCollection<Tuple<DateTime,DateTime>>();
        public ObservableCollection<Tuple<DateTime, DateTime>> Dates { get { return _dates; } }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
            PopulateList();
        }
        private void PopulateList()
        {
            _dates.Add(new Tuple<DateTime, DateTime>(DateTime.Now, DateTime.Now));
            _dates.Add(new Tuple<DateTime, DateTime>(DateTime.Now, DateTime.Now));
            _dates.Add(new Tuple<DateTime, DateTime>(DateTime.Now, DateTime.Now));
        }
    }
