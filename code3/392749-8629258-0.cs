    public sealed class Singleton
    {
        static Singleton instance;
        static Singleton()
        {
            instance = new Singleton();
        }
        public static Singleton Instance
        {
            get { return instance; }
        }
    }
