public void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterSingleton<A>();
    containerRegistry.Register<IA, A>();
    containerRegistry.Register<IAprime, A>();
}
Sure if you need one instance of A, and A must be registered as IA, IAprime.
