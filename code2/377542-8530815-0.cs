    void RootFrame_Navigating(object sender, NavigatingCancelEventArgs e)
    {
        // Only care about MainPage 
        if (e.Uri.ToString().Contains("/MainPage.xaml") != true) 
             return;
    
        var password = GetPasswordFromSomePersistentStorage();
    
        // Cancel current navigation and schedule the real navigation for the next tick 
        // (we can't navigate immediately as that will fail; no overlapping navigations 
        // are allowed) 
        e.Cancel = true; 
        RootFrame.Dispatcher.BeginInvoke(delegate 
        { 
            if (string.IsNullOrWhiteSpace(password)) 
                RootFrame.Navigate(new Uri("/InputPassword.xaml", UriKind.Relative)); 
            else 
                RootFrame.Navigate(new Uri("/ApplicationHome.xaml", UriKind.Relative)); 
        });
    }
