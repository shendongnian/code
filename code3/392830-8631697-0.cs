    public class Foo
    {
        public static readonly Foo Default = new Foo(42);
        public Foo(int bar)
        {
            Bar = bar;
        }
        
        public int Bar { get; private set; }
    }
