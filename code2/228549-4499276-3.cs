    public class FeedSingletonRepository
    {
        private static readonly object _padlock = new object();
        private static Dictionary<Type, Feed> _singletons = new Dictionary<Type, Feed>();
    
        public static T GetFeed<T>() where T:Feed
        {
            lock(_padlock)
            {
                 if (!_singletons.ContainsKey(typeof(T))
                 {
                     _singletons[typeof(T)] = typeof(T).GetInstance();
                 }
                 return _singletons[typeof(T)];
            }
        }
    }
