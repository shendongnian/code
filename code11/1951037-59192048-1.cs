    namespace WpfApp1
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
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Telemetry.tc.TrackTrace("this is a test message");
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                Telemetry.tc.TrackEvent("my_event");
                Telemetry.tc.TrackTrace("in another one, test message");
            }
        }
    }
