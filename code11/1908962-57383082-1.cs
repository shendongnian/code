    public partial class TimeWindow : Window
    {
        ...
        private void DemoVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            MainWindow._instance.SkipVideo();
        }
    }
    
