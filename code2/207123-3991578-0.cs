    class Foo
    {
        public int SomeId { get; set; }
    }
    class Bar
    {
        public int SomeId { get; set; }
    }
    class FooWithBars
    {
        public Foo Foo { get; set; }
        public IEnumerable<Bar> Bars { get; set; }
    }
...
    List<Foo> foos = new List<Foo>();
    List<Bar> bars = new List<Bar>();
    foos.Add(new Foo() { SomeId = 1 });
    foos.Add(new Foo() { SomeId = 2 });
    bars.Add(new Bar() { SomeId = 1 });
    bars.Add(new Bar() { SomeId = 1 });
    // get all foos and matching bars
    var combined = from foo in foos
                    join bar in bars
                    on foo.SomeId equals bar.SomeId into g
                    select new FooWithBars
                    {
                        Foo = foo,
                        Bars = g.Any() ? g : null
                    };
