    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MainWindow), new PropertyMetadata("Hello world"));
        public string Text 
        { 
            get { return (string)GetValue(TextProperty); } 
            set { this.SetValue(TextProperty, value); } 
        }
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        protected void HandleClick(object sender, RoutedEventArgs e)
        {
            this.Text = "Hello, World";
        }
    }
