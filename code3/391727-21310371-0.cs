    private Frame rootFrame = null;
    protected override async void OnLaunched(LaunchActivatedEventArgs args)
    {
        ...
        SettingsPane.GetForCurrentView().CommandsRequested += App_CommandRequested;
    }
    private void App_CommandRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
    {
    SettingsCommand cmdSnir = new SettingsCommand("cmd_snir", "Snir's Page", 
                  new Windows.UI.Popups.UICommandInvokedHandler(onSettingsCommand_Clicked));
    args.Request.ApplicationCommands.Add(cmdSnir);
    }
    
    void onSettingsCommand_Clicked(Windows.UI.Popups.IUICommand command)
    {
    if (command.Id.ToString() == "cmd_snir")
          rootFrame.Navigate(typeof(MainPage)); //, UriKind.RelativeOrAbsolute);
                    
    }
