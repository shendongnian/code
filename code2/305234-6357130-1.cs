    public class Foo : List<Bar>
    {
        public Foo()
        {}
        public Foo(IEnumerable<Bar> collection)
            : base(collection)
        {}
    }
