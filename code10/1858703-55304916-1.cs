    using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
    // ....
    protected readonly Query systemMenuButton = x => x.Marked("SettingsToolbarItem");
    //....
    public void TapSettingsButton()
    {
        app.Tap(systemMenuButton);
        app.Screenshot("Tapped Settings Button");
    }
