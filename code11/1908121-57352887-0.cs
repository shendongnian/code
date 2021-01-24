    public static ApplicationDataCompositeValue composite;
    public App()
    {
        this.InitializeComponent();
        this.Suspending += OnSuspending;
        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        composite = (Windows.Storage.ApplicationDataCompositeValue)localSettings.Values["nutritionSettings"];
    }
