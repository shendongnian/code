    private void Application_Activated(object sender, ActivatedEventArgs e)
    {
        RootFrame.Navigated += RootFrame_Navigated;
    }
    
    void RootFrame_Navigated(object sender, NavigationEventArgs e)
    {
        RootFrame.Navigated -= RootFrame_Navigated;
        RootFrame.Navigate(new Uri("/TestPage.xaml", UriKind.Relative));
    }
