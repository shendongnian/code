    public void TapSystemMenuButton()
    {
        if (app is iOSApp)
            app.Tap(systemMenuButton);
        else
            app.Tap(x => x.Class("ActionMenuItemView").Index(1));
    
        app.Screenshot("Tapped System Menu Button");
    }
