    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private bool _isRunning = false;
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; OnPropertyChanged("IsRunning"); }
        }
        public RelayCommand IsRunningCommand { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            IsRunningCommand = new RelayCommand(ToggleRunning);
            DataContext = this;
        }
        public void ToggleRunning()
        {
            IsRunning = !IsRunning;
        }
    }
