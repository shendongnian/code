    public void OnNavigatedFrom(INavigationParameters parameters)
    {
       
        parameters.Add("merchant", Merchant);
    }
