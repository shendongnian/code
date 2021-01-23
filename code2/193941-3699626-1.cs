    class MyClass
        static int _staticProperty;
        public static int StaticProperty
        {
            get { return _staticProperty; }
        }
    
        public static int IncrementProperty()
        {
            // increments _staticProperty ATOMICALLY
            // and returns its previous value
            return Interlocked.Increment(_staticProperty);
        }
    }
