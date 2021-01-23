    public class Configuration
    {
        static Configuration()
        {
            Current = new Configuration();
        }
    
        public static Configuration Current { get; private set; }
    }
