     public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                SevenSegmentColor =new SolidColorBrush(Color.FromRgb(251, 23, 23));
                DataContext=this;
            }
    
            public SolidColorBrush SevenSegmentColor { get; set; }
    
        }
