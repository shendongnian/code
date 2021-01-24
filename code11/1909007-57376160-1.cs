    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _feedbackText;
        public event PropertyChangedEventHandler PropertyChanged;
    
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            FeedbackText = "Awaiting start of process...";
        }
    
        public string FeedbackText
        {
            get
            {
                return _feedbackText;
            }
            set
            {
                _feedbackText = value;
                OnPropertyChanged("FeedbackText");
            }
    
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private void FinishedWorksheet(object sender, EventArgs e)
        {
            FeedbackText = "Done another worksheet";
        }
    }
