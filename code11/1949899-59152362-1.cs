    protected override void OnActivated(IActivatedEventArgs e)
    {
        var eventArgs = e as ProtocolActivatedEventArgs;
        var data = new ActivationArgs(e.Kind, eventArgs.Uri.Query);
    
        AddResources();
    
        Run(e, data);
    }
    
    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
    #if RELEASE
        var data = new ActivationArgs(e.Kind, e.Arguments);
    #else
        var data = new ActivationArgs(ActivationKind.Protocol, e.Arguments);
    #endif
    
        AddResources();
    
        Run(e, data);
    }
    
    private static void AddResources()
    {
        var applicationMergedDictionaries = Application.Current.Resources.MergedDictionaries;
        applicationMergedDictionaries.Add(GetResourceDictionary("ms-appx:///Test.Xamarin.Forms.Themes.UWP/Brushes.xaml"));
        applicationMergedDictionaries.Add(GetResourceDictionary("ms-appx:///Test.Xamarin.Forms.Themes.UWP/CustomStyles.xaml"));
        applicationMergedDictionaries.Add(GetResourceDictionary("ms-appx:///Test.HTMobile.Core.UWP/Styles.xaml"));
        applicationMergedDictionaries.Add(GetResourceDictionary("ms-appx:///Test.CRFramework.Xamarin.Forms.UWP/Root.xaml"));
    }
