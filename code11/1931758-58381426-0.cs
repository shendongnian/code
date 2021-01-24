    public void OnNavigatedTo(INavigationParameters parameters)
    {
        if(Merchant == null)
           Merchant = parameters.GetValue<Merchant>("merchant");
    }
