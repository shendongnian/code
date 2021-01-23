    Page1.xaml.cs:
        string Page1 = "Page1";
        
            protected override void OnNavigatedTo(object sender, NavigationEventArgs e)
            {
               if (App.IsBackwardNavigation)
        {
        
        if (!Page1.Equals(App.NavigationContext)
            {
    //since this page's name is not the correct page, the page will go back again.
            if (NavigationService.CanGoBack)
               NavigationService.GoBack();
            }
            else
            {
    //this is the page we're trying to get to
            App.IsBackwardNavigation = false;
            App.NavigationContext = string.Empty;
    
    
            }
        
        } 
            }
        }
