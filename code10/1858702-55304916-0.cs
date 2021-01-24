    public void TapSettingsButton()
    {
        if (app is iOSApp)
            app.Tap(systemMenuButton);
        else
            app.Tap(x => x.Class("ActionMenuItemView"));
        app.Screenshot("Tapped Settings Button");
    }
