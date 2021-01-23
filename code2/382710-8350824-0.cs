    // .NET Singleton
    sealed class Singleton 
    {
        private Singleton() {}
        public static readonly Singleton Instance = new Singleton();
    }
