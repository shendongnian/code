    public static class ServiceFactory
    {
        private static readonly container = new Foo();
        public static Instance { get { return container; } }
    }
