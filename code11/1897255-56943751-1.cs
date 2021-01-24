    public SplashScreen()
    {
        //Everything else I need in this page
        BindingContext = new MainPageViewModel();
    }
    private MainPageViewModel ViewModel => BindingContext as MainPageViewModel;
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.LoadData();
        ShowLogin();
    }
