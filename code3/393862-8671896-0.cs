    public class SettingsWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public SettingsWindow()
        {
            // We are acting as our own 'ViewModel'
            DataContext = this;
            InitializeComponent();
        }
    
        private Color _defColor;
        public Color defColor
        {
            get { return _defColor; }
            set
            {
                if (_defColor != value)
                {
                    _defColor = value;
                    if(null != PropertyChanged)
                    {
                        PropertyChanged(this, "defColor");
                    }
                }
            }
        }
    }
