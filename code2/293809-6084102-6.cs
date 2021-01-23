     /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window,INotifyPropertyChanged
        {
            private SolidColorBrush sevenSegmentColor;
            public MainWindow()
            { 
                InitializeComponent();
               SevenSegmentColor =new SolidColorBrush(Color.FromRgb(251, 23, 23));
            }
    
            public SolidColorBrush SevenSegmentColor
            {
                get
                {
                    return sevenSegmentColor;
                }
                set
                {
                    sevenSegmentColor = value;
                    // Call OnPropertyChanged whenever the property is updated
                    OnPropertyChanged("SevenSegmentColor");
                }
            }
    
            // Declare the event
            public event PropertyChangedEventHandler PropertyChanged;
    
            // Create the OnPropertyChanged method to raise the event
            public void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }
