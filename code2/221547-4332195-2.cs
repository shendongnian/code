    public class ClassWithLazyMember
    {
        Lazy<String> lazySource;
        public String LazyValue { get { return lazySource.Value; } }
        public ClassWithLazyMember()
        {
            lazySource = new Lazy<String>(GetStringFromDatabase);
        }
        public String GetStringFromDatabase()
        {
            return "Hello, Lazy World!";
        }
    }
