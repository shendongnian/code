    public void Button_Click()
    {
        AnotherWindow w;
        using (var scope = App.Container.BeginLifetimeScope())
            w = scope.Resolve<SplashScreen>();
        w?.Show();
    }
