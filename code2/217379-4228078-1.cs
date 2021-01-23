    public struct Foo
    {
        // Internal method to be called. Takes a value-type parameter
        internal void Test(int someParam)
        {
            Console.WriteLine(someParam);
        }
    
        public delegate void MyDelegate(ref Foo foo, int someParam);
    
        // Creates type-safe delegate
        private static MyDelegate GetTestDelegate()
        {
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var methodInfo = typeof(Foo).GetMethod("Test", flags);
            return (MyDelegate) Delegate.CreateDelegate
                                (typeof(MyDelegate), methodInfo);       
        }
    
        static void Main()
        {
            Foo foo = new Foo();
            MyDelegate action = GetTestDelegate();
    
            // should dodge boxing
            action(ref foo, 42);
        }
    }
