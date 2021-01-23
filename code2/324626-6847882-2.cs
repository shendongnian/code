    public sealed class Singleton
    {
        // Because Singleton's constructor is private, we must explicitly
        // give the Lazy<Singleton> a delegate for creating the Singleton.
        private static readonly Lazy<Singleton> instanceHolder =
            new Lazy<Singleton>(() => new Singleton());
        private Singleton()
        {
            ...
        }
        public static Singleton Instance
        {
            get { return instanceHolder.Value; }
        }
    }
