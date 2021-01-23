    class Foo
    {
        public ImmutableList<int> myList { get; private set; }
        public Foo(IEnumerable<int> list)
        {
            myList = list.ToImmutableList();
        }
    }
