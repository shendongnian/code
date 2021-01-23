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
    public MainWindow()
    {
        InitializeComponent();
        progressBar1.SetBinding(ProgressBar.ValueProperty, new Binding("ProgressTotal"));
        progressBar1.DataContext = _foo;
    }
