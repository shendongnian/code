    private void Video_OnLoaded(object sender, RoutedEventArgs e)
    {
        VideoMediaElement.Play();
    }
    private void Video_OnMediaEnded(object sender, RoutedEventArgs e)
    {
        VideoMediaElement.Position = TimeSpan.FromSeconds(0);
        VideoMediaElement.Play();
    }
