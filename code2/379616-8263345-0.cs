    protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
    {
        PhoneApplicationService.Current.State["name"] = "value";
        base.OnNavigatedFrom(e);
    }
