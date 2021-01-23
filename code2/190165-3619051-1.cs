    struct C
    {
        public int Foo { get; private set; }
        public int Bar { get; private set; }
        private C (int foo, int bar) : this()
        {
            this.Foo = foo;
            this.Bar = bar;
        }
        public static C Empty = default(C);
        public C WithFoo(int foo)
        {
            return new C(foo, this.Bar);
        }
        public C WithBar(int bar)
        {
            return new C(this.Foo, bar);
        }
        public C IncrementFoo()
        {
            return new C(this.Foo + 1, bar);
        }
        // etc
    }
    ...
    C c = C.Empty;
    c = c.WithFoo(10);
    c = c.WithBar(20);
    c = c.IncrementFoo();
    // c is now 11, 20
