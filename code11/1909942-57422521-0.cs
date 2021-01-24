    internal class RootObject
    {
        public Dictionary<string, bool> permissions { get; set; } = new Dictionary<string, bool> {
            { "response.ping", false },
            { "response.helloworld", false },
            // add more here...
        };
        public int points { get; set; }
    }
