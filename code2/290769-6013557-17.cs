    // Defined on same level as the LoginManager
    public interface ILoginManagerConfiguration
    {
        Uri Login { get; }
        Uri Target { get; }
        string MainRegionName { get; }
    }
    // Defined closed to the composition root
    private sealed class LoginManagerConfiguration
        : ILoginManagerConfiguration
    {
        public Uri Login { get; set; }
        public Uri Target { get; set; }
        public string MainRegionName { get; set; }
    }
