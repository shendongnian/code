    public class LoginManagerConfiguration
        : ILoginManagerConfiguration
    {
        public string MainRegionName { get; set; }
        public Uri Login { get; set; }
        public Uri Target { get; set; }
    }
