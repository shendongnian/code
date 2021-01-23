    Foo _foo = new Foo();
    DispatcherTimer _dispatcherTimer = new DispatcherTimer();
    public MainWindow()
    {
        InitializeComponent();
        _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
        _dispatcherTimer.Tick += _dispatcherTimer_Tick;
        _dispatcherTimer.Start();
        progressBar1.SetBinding(ProgressBar.ValueProperty, new Binding("ProgressTotal"));
        progressBar1.DataContext = _foo;
    }
    private void _dispatcherTimer_Tick(object sender, EventArgs e)
    {
        _foo.ProgressTotal = (_foo.ProgressTotal + 10) % progressBar1.Maximum;
    }
    public class Foo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double _progressTotal = 0;
        public double ProgressTotal
        {
            get { return _progressTotal; }
            set 
            {
                if (value != _progressTotal)
                {
                    _progressTotal = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ProgressTotal"));
                    }
                }
            }
        }
    }
