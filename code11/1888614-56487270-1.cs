    Master_PageViewModel parentViewModel
    public MessagePageViewModel(INavigation navigation, Master_PageViewModel viewModel)
    {
        ReloadCommand = new Command(async () => await ReloadPage());
        Navigation = navigation;
        parentViewModel = viewModel;
        // ...
    }
