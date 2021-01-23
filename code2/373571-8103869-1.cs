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
    
            private void CoolButton_Click(object sender, RoutedEventArgs e)
            {
                InputBox.Visibility = System.Windows.Visibility.Visible;
            }
    
            private void YesButton_Click(object sender, RoutedEventArgs e)
            {
                InputBox.Visibility = System.Windows.Visibility.Collapsed;
    
                // Do something with the Input
                //String input = InputTextBox.Text;
            }
    
            private void NoButton_Click(object sender, RoutedEventArgs e)
            {
                InputBox.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
