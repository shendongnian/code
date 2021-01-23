    class MyBase
    {
        private MyBase(string someParam)
        {
            // some code
        }
    
        public static MyBase Create(string someParam)
        {
            return new MyBase(someParam);
        }
    }
    
    class MyDerived : MyBase
    {
        public MyDerived()
            : base("foo") // won't compile, as requested
        { }
    }
