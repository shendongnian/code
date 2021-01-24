    public MainPage()
    {
       WebView.ClassId = ((App)(App.Current)).InstanceId;
    }
    protected override bool OnBackButtonPressed()
    {
        if (Settings.ActiveInstanceId == WebView.ClassId)
        {
            if (WebView.CanGoBack)
            {
                WebView.GoBack();
                return true;
            }
        }
        return base.OnBackButtonPressed(); 
    }
   
