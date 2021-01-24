    public sealed class DataProvider
    {
        public DataProvider()
        {
            _cache = new Lazy<List<string>>(createCache);
        }
        public void DoSomethingThatNeedsCachedList()
        {
            var list = _cache.Value;
            // Do something with list.
            Console.WriteLine(list[10]);
        }
        readonly Lazy<List<string>> _cache;
        List<string> createCache()
        {
            // Dummy implementation.
            return Enumerable.Range(1, 100).Select(x => x.ToString()).ToList();
        }
    }
