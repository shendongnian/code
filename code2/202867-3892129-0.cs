    public static void Main()
    {
        SplashScreen splashScreen = new SplashScreen("whatever.jpg");
        splashScreen.Show(true);
        bool dataLoaded = LoadDataFromDatabase();
        WpfApplication1.App app = new WpfApplication1.App();
        app.StartupUri = new Uri(dataLoaded ? "MainWindow.xaml" : "ErrorWindow.xaml", UriKind.Relative);
        app.Run();
    }
