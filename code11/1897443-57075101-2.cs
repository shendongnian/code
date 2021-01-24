    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
       containerRegistry.RegisterForNavigation<NavigationPage>();
       AppContainer = containerRegistry.GetContainer(); //Assigning actual dryioc container
    }
