    private async void NavigateToMainMenu()
    {
        LoadingIcon = Visibility.Visible;
        await Task.Delay(60);
        string mainUri = nameof(SomeRoute.MainMenu);
        _regionManager.RequestNavigate(Regions.MainRegion, mainUri);
    }
