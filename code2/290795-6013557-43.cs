    private sealed class LoginManagerConfiguration
    {
        public Uri Login { get; private set; }
        public Uri Target { get; private set; }
        public string MainRegionName { get; private set; }
        public LoginManagerConfiguration(Uri login, Uri target, string mainRegionName)
        {
            this.Login = login;
            this.Target = target;
            this.MainRegionName = mainRegionName;
        }
    }
