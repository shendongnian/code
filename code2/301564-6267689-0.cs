    public class Foo
    {
        public Foo(int i) { Debug.WriteLine(i); }
    }
    
    public class Bar: Foo
    {
        public Bar() : base(4) {} // Prints '4' to debug via the base class's constructor.
    }
