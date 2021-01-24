    public App()
    {
        InitializeComponent();
        if (Application.Current.Properties.ContainsKey("PushDisabled"))
        {
            //Do things when push is disabled...
            OneSignal.SetSubscription(false);
            Xamarin.Essentials.Preferences.Set("SetSubcription", false);
        }
        else
        {
            Application.Current.Properties["PushDisabled"] = false;
            //Do things when push is enabled...
            OneSignal.SetSubscription(true);
            Xamarin.Essentials.Preferences.Set("SetSubcription", true);
        }
            OneSignal.Current.StartInit("one-signal-key").EndInit();
    }
