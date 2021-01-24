    public class ABC
    {
        private readonly ICache _cache;
        public ABC()
        {
            _cache = new Cache();
        }
        public ABC(ICache cache)
        {
            _cache = cache;
        }
    }
