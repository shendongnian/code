    // Some other project
    public static class UnityConfig
    {
        public static IUnityContainer Container { get; set; }
    }
    var unity = new UnityConfig();
    IUnityContainer unityContainer = UnityConfig.GetConfiguredContainer();
    project.namespace.UnityConfig.Container = unityContainer;
