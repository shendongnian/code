    public class MainPage
    {
    
        private DispatcherTimer _dt;
        
        public MainPage()
        {
            _dt = new DispatcherTimer();
        }
        
        private void startButton_Click(object sender, RoutedEventArgs e)
        {
             _dt.Start();
        }
    }
        
