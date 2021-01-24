    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Flag = true;
            OnPropertyChanged("Flag");
        }
        
        public bool Flag { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    
