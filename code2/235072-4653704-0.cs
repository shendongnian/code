        abstract class TypeBase
        {
            private static bool _initialized;
    
            protected static void Initialize()
            {
                if (!_initialized)
                {
                    Type<int>.Instance = new Type<int> {Name = "int"};
                    Type<long>.Instance = new Type<long> {Name = "long"};
                    Type<double>.Instance = new Type<double> {Name = "double"};
                    _initialized = true;
                }
            }
        }
    
        class Type<T> : TypeBase
        {
            private static Type<T> _instance;
    
            public static Type<T> Instance
            {
                get
                {
                    Initialize();
                    return _instance;
                }
                internal set { _instance = value; }
            }
    
            public string Name { get; internal set; }
        }
