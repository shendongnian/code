    class Material
    {
        class Keys
        {
            public static int Length;
        }
        string Keys { get; set; }
        public void Process()
        {
            // Does this refer to string.Length (via property Keys)
            // or Material.Keys.Length? It actually refers to both.
            Console.WriteLine(Keys.Length);
        }
    }
