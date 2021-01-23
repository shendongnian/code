    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _height;
        public int CustomHeight
        {
            get { return _height; }
            set
            {
                if (value != _height)
                {
                    _height = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("CustomHeight"));
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            CustomHeight = 500;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomHeight = 100;
        }
    }
