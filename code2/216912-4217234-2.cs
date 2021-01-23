    public class Config
    {
        public Config()
        {
            Test1 = new List<string>();
            Test2 = nix;
        }
        public List<string> Test1 { get; set; }
        public string[] Test2 { get; set; }
        private static readonly string[] nix = new string[0];
        public static Config CreateDefault()
        {
            Config config = new Config();
            config.Test1.Add("A");
            config.Test1.Add("B");
            config.Test2 = new string[2] { "A", "B" };
            return config;
        }
    }
