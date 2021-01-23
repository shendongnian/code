    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> lazy =
            new Lazy<Singleton>(() => new Singleton(),LazyThreadSafetyMode.ExecutionAndPublication);
    
        private Singleton()  {  }
        public static Singleton Instance { get { return lazy.Value; } }
    }
