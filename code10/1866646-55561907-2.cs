    void SetTaskbarRelaunchCommand(Form form)
    {
        // WARNING, once RelaunchCommand has been set it can't be changed for any given appID.
        // Workaround: delete all links here related to our app.
        // %AppData%\Microsoft\Internet Explorer\Quick Launch\User Pinned\ImplicitAppShortcuts
        // %AppData%\Microsoft\Internet Explorer\Quick Launch\User Pinned\TaskBar
        // Source: https://stackoverflow.com/a/28388958/33236
        var appID = "MyAppID";
        var path = @"C:\Program Files (x86)\MyApp\Updater.exe");
        var handle = form.Handle;
        var propGuid = new Guid("{9F4C2855-9F79-4B39-A8D0-E1D42DE1D5F3}");
        var ID = new PropertyKey(propGuid, 5);                          // System.AppUserModel.ID
        var RelaunchCommand = new PropertyKey(propGuid, 2);             // System.AppUserModel.RelaunchCommand
        var RelaunchDisplayNameResource = new PropertyKey(propGuid, 4); // System.AppUserModel.RelaunchDisplayNameResource
        WindowProperties.SetWindowProperty(handle, ID, appID);
        WindowProperties.SetWindowProperty(handle, RelaunchCommand, path);
        WindowProperties.SetWindowProperty(handle, RelaunchDisplayNameResource, "Label of My App");
    }
