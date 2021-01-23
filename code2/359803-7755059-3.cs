    public class SomeClass
    {
        private readonly Lazy<string> _someField = new Lazy<string>(() => new string('-', 10000000), true);
    
        private readonly object _lazyLock = new object();
    
    
        public string SomeField
        {
            get
            {
                return _someField.Value;
            }
        }
    }
