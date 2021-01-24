    public interface ICache
    {
        bool Contains(string key);
        T Retrieve<T>(string key);
        void Store(string key, object data);
        void Remove(string key);
    }
    public static class MyNugetLibrary
    {
        public static ICache Cache { get; set; } = DefaultCache;
        public readonly static ICache DefaultCache = new MemoryCache();
        public readonly static ICache NoCache = new UnCache();
        [Cache]
        public static int DoSomethingExpensiveAndUseful(this string input)
        {
            return input.Length;
        }
        [Cache]
        public static int DoSomethingElseExpensiveAndUseful(this string input)
        {
            return (int)input.ToCharArray().First();
        }
    }
