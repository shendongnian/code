    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        isEnabledVM = (e.Parameter as ViewModel);
    }
    private ViewModel isEnabledVM { get; set; }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        isEnabledVM.IsEnabled = false;
    }
