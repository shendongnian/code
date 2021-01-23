    public class MediaWindow
    {
        private MediaElement video = new MediaElement { Width = 400, Height = 400};
    
        public void SetVideoSource(string path)
        {
            video.Source = new Uri(path, UriKind.Relative);
        }
    
        private void play_Click(object sender, RoutedEventArgs e)
        {
           video.Play();
        }
        
        private void stop_Click(object sender, RoutedEventArgs e)
        {
           video.Stop(); 
        }
    }
