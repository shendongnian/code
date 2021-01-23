    class Foo
    {
        public int Baz { get; set; }
    }
    class Bar
    {
        public Func<Foo> fooGetter;
        public Bar(Func<Foo> fooGetter)
        {
            this.fooGetter = fooGetter;
        }
        public void Do()
        {
            Console.WriteLine(fooGetter().Baz);
        }
    }
