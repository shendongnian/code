    private string appid;
    // ..
    appid = link.AppUri;
    // ..
    private void App_Name_Click(object sender, RoutedEventArgs e)
    {
        ShowMarket(appid);
    }
    
    private void ShowMarket(string id)
    {
        MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
        marketplaceDetailTask.ContentIdentifier = id;
        marketplaceDetailTask.Show();
    }
