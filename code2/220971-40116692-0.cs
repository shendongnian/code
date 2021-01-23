    using System.Windows;
    namespace WpfApplication4
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
                button.Visibility = Visibility.Hidden;
            }
    
            private void button2_Click(object sender, RoutedEventArgs e)
            {
                button.Visibility = Visibility.Visible;
            }
        }
    }
