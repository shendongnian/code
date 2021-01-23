    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ApplicationVM();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ((IGestureSink)(this.DataContext)).DoGesture();
        }
    }
