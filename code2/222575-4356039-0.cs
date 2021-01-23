    class Test
    {
        delegate int FooDelegate(int i);
        static FooDelegate Foo = FooImplementation;
        static int FooImplementation(int i)
        {
            return i + 1;
        }
        public static void Main()
        {
            Inject();
            Foo(1);
        }
        public static void Inject()
        {
            var oldImpl = Foo;
            Foo = i =>
                {
                    try
                    {
                        BeginDebug();
                        return oldImpl(i);
                    }
                    finally
                    {
                        EndDebug();
                    }
                };
        }
        public static void BeginDebug()
        {
            Console.WriteLine("Begin Foo");
        }
        public static void EndDebug()
        {
            Console.WriteLine("End Foo");
        }
    }
