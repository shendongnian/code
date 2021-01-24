    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            // Blue rectangle
            // Initialize the command that is binded to one of your buttons
            BlueRectangleSwitchCommand = new RelayCommand(o => 
            {
                // Switches the flag binded to Visibility property of one of your Rectangles
                IsBlueRectangleVisible = !IsBlueRectangleVisible;
                // Notify that UI shoud be re-rendered
                OnPropertyChanged(nameof(IsBlueRectangleVisible));
            });
            // Next line is needed in order to bind this object to the DataContext of itself (wierd, isn't it?)
            // So the MainWindow would know where to llok up for the properties you are binding to in XAML
            DataContext = this;
        }
        // Blue rectangle
        // Property that is binded to Visibility property of one of your Rectangles
        public bool IsBlueRectangleVisible { get; set; }
        // Blue rectangle
        // Property that is binded to Command property of one of your Rectangles
        public ICommand BlueRectangleSwitchCommand { get; private set; }
        // Blue rectangle
        // This implementation of INotifyPropertyChanged interface allows you to use OnPropertyChanged 
        // that is needed for notifying UI that your properties changed
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
        // Green rectangle
        private void GreenRectangleBtnClick(object sender, RoutedEventArgs e)
        {
            greenRectangle.Visibility = greenRectangle.Visibility == Visibility.Visible
                ? Visibility.Collapsed
                : Visibility.Visible;
        }
    }
