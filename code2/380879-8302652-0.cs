    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            this.Stopwatch = new Stopwatch();
            this.Stopwatch.Start();
            this._timer = new Timer(
                new TimerCallback((s) => this.FirePropertyChanged(this, new PropertyChangedEventArgs("Stopwatch"))),
                null, 1000, 1000);
            InitializeComponent();
        }
        private void FirePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(sender, e);
            }
        }
        private Timer _timer;
        public Stopwatch Stopwatch { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
