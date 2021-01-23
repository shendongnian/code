    public class SomeClass
    {
        private string _someField;
    
        private readonly object _lazyLock = new object();
    
    
        public string SomeField
        {
            get 
            {
                // we'd also want to do synchronization if multi-threading.
                if (_someField == null)
                {
                    lock (_lazyLock)
                    {
                        if (_someField == null)
                        {
                            _someField = new String('-', 1000000);
                        }
                    }
                }
    
                return _someField;
            }
        }
    }
