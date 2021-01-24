    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public static readonly DependencyProperty SectionTitleProperty = DependencyProperty.Register(
            nameof(SectionTitle),
            typeof(SectionTitle),
            typeof(MainWindow));
        public SectionTitle SectionTitle
        {
            get
            {
                return (SectionTitle)GetValue(SectionTitleProperty);
            }
            set
            {
                SetValue(SectionTitleProperty, value);
                OnPropertyChanged();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SectionTitle = SectionTitle.TitleBlock;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
