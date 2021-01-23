    public class ClassWithLazyMember
    {
        Lazy<String> lazySource;
        public String LazyValue
        {
            get
            {
                if (lazySource == null)
                {
                    lazySource = new Lazy<String>(GetStringFromDatabase);
                    // Same as lazySource = new Lazy<String>(() => "Hello, Lazy World!");
                    // or lazySource = new Lazy<String>(() => GetStringFromDatabase());
                }
                return lazySource.Value;
            }
        }
        public String GetStringFromDatabase()
        {
            return "Hello, Lazy World!";
        }
    }
