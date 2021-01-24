    public MainPageViewModel(MainPage mainPage)
    {
        
        RotateCommand = new Command(HandleRotateCommand,
            () => true);
        //if i uncomment this, the button fires.  not ideal obviously.
        //mainPage.RotateButton.Command = RotateCommand;
        mainPage.BindingContext = this;
    }
