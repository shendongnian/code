protected void Application_Start() {
    // ...
 
    var oldProvider = FilterProviders.Providers.Single(
        f => f is FilterAttributeFilterProvider
    );
    FilterProviders.Providers.Remove(oldProvider);
 
    var container = new UnityContainer();
    var provider = new UnityFilterAttributeFilterProvider(container);
    FilterProviders.Providers.Add(provider);
 
    // ...
}
