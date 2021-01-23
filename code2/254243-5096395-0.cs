    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Box2.Foreground = Brushes.Black;
            Box1.IsEnabled = false;
            Box2.IsEnabled = false;
            Box2.ClearValue(TextBox.ForegroundProperty);
        }
    }
