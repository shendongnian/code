    private void App_Name_Click(object sender, RoutedEventArgs e)
    {
        ShowMarket("Marketplace GUID");
    }
    
    private void ShowMarket(string id)
    {
        MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
        marketplaceDetailTask.ContentIdentifier = id;
        marketplaceDetailTask.Show();
    }
