    using System.Windows;
    
    namespace Test
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
            {
                MainFrame.NavigationService.Navigate(new HomePage());
            }
        }
    }
