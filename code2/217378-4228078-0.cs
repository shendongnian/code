    public struct Foo
    {
        // Internal method to be called, taking a value-type parameter
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
                         (typeof(MyDelegate), null, methodInfo);       
        }
    
        static void Main()
        {
            Foo foo = new Foo();
            MyDelegate action = GetTestDelegate();
    
            action(ref foo, 42);
        }
    }
