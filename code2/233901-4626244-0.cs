    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                radioButton1.IsChecked = false;
            }
        }
    }
