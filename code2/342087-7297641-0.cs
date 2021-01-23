    public void YourFunction()
    {
    App.PageContext = "MainPage";
    App.IsBackwardNavigation = true;
    
    if (NavigationService.CanGoBack)
       NavigationService.GoBack();
    }
