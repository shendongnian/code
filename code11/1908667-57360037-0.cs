    protected override async void OnAppearing()
    {
        base.OnAppearing();
    
        login = new List<Login>();
    
        //show ActivityIndicator
    
        List<Login> items = await App.dataManager.GetLoginAsync();
    
        //hide ActivityIndicator
    
        if (items.Count <= 0)
        {
            await Navigation.PushAsync(Registration);
        }
        else
        {
            await Navigation.PushAsync(LoginPage);
        }
    }
