    public void Pushpin_ManipulationStarted(object sender,  ManipulationStartedEventArgs e)
    {
        var pushPin = (PushPin)sender;
        var title = pushPin.Content;
        NavigationService.Navigate(new Uri("/blahblah.xaml?info=" + title, UriKind.Relative));
    }
