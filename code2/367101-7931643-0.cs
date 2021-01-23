    class Program
        {
            static Lazy<string> _Lazy;
            static string _connectionString;
    
            public string LazyValue
            {
                get
                {
                    return _Lazy.Value;
                }
    
            }
    
            public static void Init(string connectionString)
            {
                _connectionString = connectionString;
                _Lazy = new Lazy<string>(() => new string(connectionString.ToArray()), System.Threading.LazyThreadSafetyMode.ExecutionAndPublication);
            }
