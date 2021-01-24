    public class HttClientProvider
    {
        private static HttpClient _instance = null;
        private static readonly object _instanceLock = new object(); 
        public static HttpClient Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (_instanceLock)
                    {
                        if (null == _instance)
                        {
                            _instance = new HttpClient();
                        }
                    }
                }
                return _instance;
            }
        }
    }
