    private void NavSample_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
    {
        if (contentFrame.CanGoBack)
        {
            contentFrame.GoBack();
            // setting selected menu 
            if(contentFrame.Content is SamplePage1) SamplePage1Item.IsSelected = true;
            else if(contentFrame.Content is SamplePage2) SamplePage2Item.IsSelected = true;
        }
    }
