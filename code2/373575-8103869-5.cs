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
                // CoolButton Clicked! Let's show our InputBox.
                InputBox.Visibility = System.Windows.Visibility.Visible;
            }
    
            private void YesButton_Click(object sender, RoutedEventArgs e)
            {
                // YesButton Clicked! Let's hide our InputBox and handle the input text.
                InputBox.Visibility = System.Windows.Visibility.Collapsed;
    
                // Do something with the Input
                //String input = InputTextBox.Text;
            }
    
            private void NoButton_Click(object sender, RoutedEventArgs e)
            {
                // NoButton Clicked! Let's hide our InputBox.
                InputBox.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
