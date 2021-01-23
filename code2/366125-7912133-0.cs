    class Foo
    {
        public Foo(int bar, int baz)
        {
            Bar = bar;
            Baz = baz;
        }
        public int Bar { get; set; }
        public int Baz;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var foos = new List<Foo>(new[]
            {
                new Foo(1, 2),
                new Foo(3, 4),
                new Foo(5, 6)
            });
            DoSomeWork(foos);
        }
        private static void DoSomeWork(IEnumerable<Foo> foos)
        {
            foreach (var foo in foos)
            {
                foo.Bar = 42;
                foo.Baz = 42;
            }
        }
    }
