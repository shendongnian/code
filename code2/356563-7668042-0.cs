    public class Circuit
    {
        // Initialize these in the constructor
        private readonly SettingCommands settings;
        private readonly EnvironmentCommands environment;
        private readonly OutputCommands output;
        public SettingCommands Settings { get { return settings; } }
        public EnvironmentCommands Environment { get { return environment; } }
        public OutputCommands Output { get { return output; } }
    }
    public class SettingCommands
    {
        public string Foo(string command) { ... }
    }
