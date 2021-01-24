    using System.Windows;
    namespace WpfApp1
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void UserControl1_MyClick(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Yep");
            }
        }
    }
