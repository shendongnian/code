    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        try
        {
            StorageFolder folder = await StorageFolder.GetFolderFromPathAsync(@"C:\");
            // do work
        }
        catch
        {
            MessageDialog dlg = new MessageDialog(
                "It seems you have not granted permission for this app to access the file system broadly. " +
                "Without this permission, the app will only be able to access a very limited set of filesystem locations. " +
                "You can grant this permission in the Settings app, if you wish. You can do this now or later. " +
                "If you change the setting while this app is running, it will terminate the app so that the " +
                "setting can be applied. Do you want to do this now?",
                "File system permissions");
            dlg.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(InitMessageDialogHandler), 0));
            dlg.Commands.Add(new UICommand("No", new UICommandInvokedHandler(InitMessageDialogHandler), 1));
            dlg.DefaultCommandIndex = 0;
            dlg.CancelCommandIndex = 1;
            await dlg.ShowAsync();
        }
    }
    
    private async void InitMessageDialogHandler(IUICommand command)
    {
        if ((int)command.Id == 0)
        {
            await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-broadfilesystemaccess"));
        }
    }
