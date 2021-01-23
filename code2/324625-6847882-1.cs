    public sealed class Singleton
    {
        private static readonly Lazy<Singleton> instanceHolder = new Lazy<Singleton>();
        private Singleton()
        {
            ...
        }
        public static Singleton Instance
        {
            get { return instanceHolder.Value; }
        }
    }
