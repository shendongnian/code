     public MainPageViewModel(INavigationService navigationService)
     {
        _navigationService = navigationService;
        NavigationCommand = new Command(ExecuteCommand);
     }
