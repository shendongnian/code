    protected override async void OnAppearing()
    {
        base.OnAppearing();
        User results = await LoginService.Login(username.Text.Trim(), password.Text.Trim());
        if (results != null)
        {
            GlobalVars.loginProfilJsonObject = results;
            Application.Current.MainPage = new MainPage();
            Console.WriteLine("Not executing");
        }
        else
        {
            await DisplayAlert("Error", "Wrong email address or password", "OK");
        }
    }
