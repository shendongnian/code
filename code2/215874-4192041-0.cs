    public sealed class Singleton
    {
        private Singleton() { }
        private static readonly Lazy<Singleton> m_instance = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance
        {
            get
            {
                return m_instance.Value;
            }
        }
    }
