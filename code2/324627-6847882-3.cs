    public sealed class Singleton
    {
        // Because Singleton's constructor is private, we must explicitly
        // give the Lazy<Singleton> a delegate for creating the Singleton.
        static readonly Lazy<Singleton> instanceHolder =
            new Lazy<Singleton>(() => new Singleton());
        Singleton()
        {
            // Explicit private constructor to prevent default public constructor.
            ...
        }
        public static Singleton Instance => instanceHolder.Value;
    }
