    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        int progressValue;
        public int ProgressValue
        {
            get { return (this.progressValue); }
            set { this.progressValue = value; this.raisePropertyChanged("ProgressValue"); }
        }
    
        public int ProgressMax
        {
            get { return (100); }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        void raisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                int counter = 0;
    
                Parallel.ForEach(Enumerable.Range(1, 100), i =>
                {
                    Interlocked.Increment(ref counter);
                        this.ProgressValue = counter;
                    Thread.Sleep(25);
                });
            });
        }
    }
