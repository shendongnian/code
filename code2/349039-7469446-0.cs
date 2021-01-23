    public abstract class Foo
    {
        public abstract int M();
    }
    public abstract class Bar : Foo
    {
        // Concrete methods can call M() in here
    }
    public class Baz : Bar
    {
        public override int M() { return 0; }
    }
