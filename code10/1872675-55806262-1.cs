    public LoginPageViewModel(INavigationService navigationService, IPushNotification pushNotification)
    {
            _navigationService = navigationService;
            LoginCommand = new DelegateCommand(async () => await BeginLoginAsync());
    }
