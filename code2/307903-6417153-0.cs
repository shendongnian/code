    public class Bar
    {
        public Bar()
        {
            Foos = new Dictionary<string, string>
            {
                { "foo", "bar" }
            };
        }
    
        public Dictionary<string, string> Foos { get; set; }
    }
