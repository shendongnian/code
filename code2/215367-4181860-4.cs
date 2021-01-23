    public sealed class MyClass
    {
        MyClass()
        {
        }
    
        public static MyClass Instance
        {
            get
            {
                return Nested.instance;
            }
        }
        
        class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }
    
            internal static readonly MyClass instance = new MyClass();
        }
    }
