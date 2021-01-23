    public partial class MainWindow : RibbonWindow, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    
        public const string NamePropertyName = "VisibleA"; 
        private bool _visibleA = true;
        public bool VisibleA
        {
            get
            {
                return _visibleA;
            }
            set
            {
                _visibleA = value;
                RaisePropertyChanged(NamePropertyName); 
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
    }
