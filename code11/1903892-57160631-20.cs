    interface IFoo
    {
        void Method1();
    }
    
    class Foo : IFoo
    {
        private static int index = 1;
        private int id;
        private static NestedFoo invoker = new NestedFoo();
        public static IFoo Invoker
        {
            get
            {
                if (invoker.Instance == null)
                {
                    Create();
                }
    
                return invoker;
            }
        }
        private Foo(int id) => this.id = id;
        public static IFoo Create()
        {
            var foo = new Foo(index++);
            invoker.Instance = foo;
            return invoker;
        }
    
        public void Method1()
        {
            Console.WriteLine(this.id);
        }
    
        private class NestedFoo : IFoo
        {
            public Foo Instance { get; set; }
            public void Method1() => Instance.Method1();
        }
    }
