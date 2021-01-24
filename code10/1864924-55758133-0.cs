    Page page;
    if (Xamarin.Forms.Device.Idiom == TargetIdiom.Tablet)
    {
        page = FreshPageModelResolver.ResolvePageModel<SplashPageModel>();
    }
    else
    {
        // We will load our phone only splash screen
        page = new SplashPagePhone();
        FreshPageModelResolver.BindingPageModel(null, page, new SplashPageModel(FreshIOC.Container.Resolve<DataService>()));
    }
    var navContainer = new FreshMvvm.FreshNavigationContainer(page)
    {
        BarTextColor = Color.White
    };
    MainPage = navContainer;
